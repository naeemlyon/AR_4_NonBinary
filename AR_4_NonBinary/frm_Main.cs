using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Reflection;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace AR_4_NonBinary
{
    public partial class frm_Main : Form
    {

        #region Class Level Variables
        COMMON CMN = new COMMON();
        private const String Comma = ",";
        private const String DLMT = "_";

        Hashtable H = new Hashtable();    // Hashtable for each case (row) erased on reading each row..
        Hashtable FI = new Hashtable();   // Hashtable for all Frequent Itemset        
        Double Freq = 0; // Frequency of Frequent Item under Consideration
        Double TotalRows = 0;  // Total Number of rows read.. (n)
        int Dimension = 0; // Number of features of dataset
        Double Threshold = 0.0;
        String AR_Lines = String.Empty;
        Hashtable Codes = new Hashtable(); 

        public frm_Main()
        {
            InitializeComponent();
            cbo_Measure.SelectedIndex = 0;
            txt_Display.Text = "uncomment three lines in InitializeComponent for detail exploitation of functionality";
        //    TotalRows = Double.Parse(  Count_Dataset_Cases().ToString());
        //    txt_Display.Text = "Total Rows: " + TotalRows.ToString() + Environment.NewLine ;
        //    txt_Display.AppendText("Total Dimension: " + Dimension.ToString());
        }

        private int  Count_Dataset_Cases()
        {
            int Counter = 0;
            if (File.Exists(CMN.OrigionalSheet) == true)
            {
                StreamReader SR = File.OpenText(CMN.OrigionalSheet);
                String[] Arr = SR.ReadLine().Split(Comma.ToCharArray());
                Dimension = Arr.Length; 
                while (!SR.EndOfStream)
                {
                    SR.ReadLine();
                    Counter++;
                }
            }
            return Counter;
        }

        #endregion

        #region Serialize Hashtable
        private void Serialize_Hashtable(Hashtable HTb, String FileName)
        {
            File.Delete(FileName); // delete any previous bin file to avoid any append
            try
            {
                Stream FL = File.Open(FileName, FileMode.Create, FileAccess.ReadWrite);
                BinaryFormatter BF = new BinaryFormatter();
                BF.Serialize(FL, HTb);
                FL.Close();
                FL.Dispose();
            }
            catch
            {
                MessageBox.Show("some error: " + FileName);
            }
        }

        private Hashtable Load_Hashtable_File(String FileName)
        {            
            Stream FL = File.Open(FileName, FileMode.Open, FileAccess.Read);
            BinaryFormatter BF = new BinaryFormatter();
            Hashtable HTb = (Hashtable)BF.Deserialize(FL);
            FL.Close();
            FL.Dispose();
            return HTb;
        }
        #endregion

        #region Digitize_Text_Matrix
        private void btn_Digitize_Text_Matrix_Click(object sender, EventArgs e)
        {
            txt_Display.Text = Digitize_Text_Matrix();
        }

        private String Digitize_Text_Matrix()
        {
            String Line = String.Empty;
            String[] Arr;
            int Offset = int.Parse(TotalRows.ToString()); // 494021;        
            String[] BigArray = new String[(Offset*Dimension)]; 
            int i = 0;            
            int Counter = 0;            
            StreamReader SR;            
            SR = File.OpenText(CMN.OrigionalSheet);
            String[] Header = SR.ReadLine().Split(Comma.ToCharArray()); // header..

            while (!SR.EndOfStream)
            {
                Line = SR.ReadLine();
                Arr = Line.Split(",".ToCharArray());
                for (i = 0; i < Arr.Length; i++)
                {                   
                    BigArray [Counter + (Offset * i)] = Arr[i];    
                } 
                Counter++;                
            }
            SR.Close();
            SR.Dispose();                                    
            //////////////////////////////////

            Hashtable H = new Hashtable();
            String S = String.Empty;
            int Indx = -1;
            int Num = 1;
           
            Counter = 0;
            for (i = 0; i < BigArray.Length; i++)
            {
                if ((i % Offset) == 0)                
                    Indx++;

                S = Header[Indx] + "(" + BigArray[i] + ")";
                if (H.Contains(S) == true)
                {
                    Num = int.Parse(H[S].ToString());
                    BigArray[i] = Num.ToString();
                }
                else
                {
                    Counter++;
                    H.Add(S, Counter);
                    BigArray[i] = Counter.ToString();
                }                
            }

            // Serialize Hashtable for decoding 
            // swap key and id in new hashtable..
            Hashtable HT = new Hashtable();
            IDictionaryEnumerator ID = H.GetEnumerator();
            while (ID.MoveNext())
            {
                HT.Add(ID.Value, ID.Key);
            }
             // SERIALIZE IT NOW..
             Serialize_Hashtable(HT, CMN.Codes);
            ///////////////////////////////////////
            /////////////////////////////////////
            String Pth = CMN.DigitizedSheet;
            File.Delete(Pth);
            StreamWriter SW = File.AppendText(Pth );
            Line = String.Empty;
            for (Counter = 0; Counter < Header.Length; Counter++)
            {
                Line += Header[Counter] + Comma;
            }
            Line = Line.Substring(0, Line.Length - 1); // remove last DLMT
            SW.WriteLine(Line);
            
            for (i = 0; i < Offset; i++)
            {
                Line = String.Empty;
                for (Counter = 0; Counter < Header.Length; Counter++)
                {
                    Line += BigArray[i + (Offset * Counter)] + Comma  ;
                }
                Line = Line.Substring(0, Line.Length - 1); // remove last DLMT
                SW.WriteLine(Line);
            }
            SW.Close();
            SW.Dispose();
            return "Done! " + Pth ;
        }

        #endregion

        #region Discretize Continuous Data

        private void btn_Discretize_Click(object sender, EventArgs e)
        {
            txt_Display.Text = Discretize_Continous_Data();
        }

        private String Discretize_Continous_Data()
        {
            String Line = String.Empty;
            Double Num = 0;

            StreamReader SR;
            SR = File.OpenText(CMN.OrigionalSheet);
            File.Delete(CMN.DiscretizedSheet); // delete any previous file ..if any..
            StreamWriter SW = File.AppendText(CMN.DiscretizedSheet);

            // first line is heading...write it as such
            SW.WriteLine(SR.ReadLine().ToString());

            while (!SR.EndOfStream)
            {

                Num = Double.Parse(SR.ReadLine());
                if ((Num >= 0) && (Num <= 170))
                    Line = "1";
                else if ((Num >= 171) && (Num <= 340))
                    Line = "2";
                else 
                    Line = "3";
                SW.WriteLine(Line);
            }
            SW.Close();
            SW.Dispose();
            SR.Close();
            SR.Dispose();
            return CMN.DiscretizedSheet +  " written";
        }

        #endregion

        #region Codfiy
        private String Codify(String FreqItem)
        {
            int i = 0;
            int Num = 65; // A
            String S = String.Empty;
            String C = String.Empty;
            String[] Arr = FreqItem.Split(DLMT.ToCharArray());                                             

            H.Clear();            
            for (i = 0; i < Arr.Length; i++)
            {
                C = Convert.ToChar(Num + i).ToString();
                S += C; // +Comma;
                H[C] = Arr[i];
            }
            //S = S.Substring(0, S.Length - 1); // remove last extra delimiter
            return S;
        }
        #endregion

        #region Generate_FI_AR

        private void btn_Generate_AR_Click(object sender, EventArgs e)
        {
            Generate_AR();            
        }

        private void btn_Generate_FI_Click(object sender, EventArgs e)
        {
            TotalRows = Generate_FI_from_Dataset();
            Double FI_Threshold = Double.Parse( tbx_FI_Threshold.Text);
            Double V = 0.0;
            Hashtable HT = new Hashtable();
            IDictionaryEnumerator ID = FI.GetEnumerator();
            while (ID.MoveNext())
            {
                V = Double.Parse(ID.Value.ToString());
                V = V / TotalRows;
                V *= 100;
                if (V >= FI_Threshold)
                    HT.Add(ID.Key, ID.Value);                
            }
            FI = HT;
            Serialize_Hashtable(FI, CMN.FI);
        }

        private void Generate_AR()
        {
            File.Delete(CMN.AR_Sheet);
            Threshold = Double.Parse(tbx_Threshold.Text);
            Codes = Load_Hashtable_File(CMN.Codes);         
            String Line = "Antecedent" + Comma + "Consequent" + Comma + "Support" + Comma + "Confidence" + Comma;
            Line += "Leverage" + Comma + "AllConfidenc" + Comma + "Correlation" + Comma + "Odds Ratio" + Comma + "Kappa" + Comma;
            Line += "Interest" + Comma + "Cosine_IS" + Comma + "Piatetsky_Shapiro" + Comma + "Collective_Strength" + Comma;
            Line += "Jaccard" + Comma + "J Measure" + Comma + "Gini Index" + Comma + "Laplace" + Comma + "Conviction" + Comma;
            Line += "Certainity Factor" + Comma + "Added Value" + Environment.NewLine;  
            File.AppendAllText(CMN.AR_Sheet, Line);

            // Display and Generate Assoc. Rules.
            String FreqItem = String.Empty;
            
            IDictionaryEnumerator ID = FI.GetEnumerator();
            while (ID.MoveNext())
            {   
                FreqItem = ID.Key.ToString();                
                FreqItem = Codify(FreqItem);                
                //txt_Display.AppendText(ID.Key.ToString() + " = " + ID.Value.ToString() + Environment.NewLine);
                // Single Freq.Item needs not to pass
                // set Support Threshold
                if (FreqItem.Length > 1)
                {
                    AR_Lines = String.Empty;
                    Freq = Double.Parse(ID.Value.ToString()); // will be used only in Association Rules writing and developement..
                    Generate_Association_Rules(FreqItem);                   
                    // append all assocication rules of this FI
                    File.AppendAllText(CMN.AR_Sheet, AR_Lines);
                }
                //txt_Display.AppendText("=======================================================" + Environment.NewLine);

                
            }
            txt_Display.Text = "All Assoc.Rules and Freq.Items Generated";
        }
        #endregion             
        
        #region Association Rules
        #region 1
        private void Generate_Association_Rules(String S)
        {
            int i = 0;          
            int[] mask = new int[20]; /* Guess what this is */
            int n = S.Length;            
            for (i = 0; i < n; ++i)
            {
                mask[i] = 0;
            }
            // all the other sub sets             
            while (Get_Next_Association_Rule(mask, n) > 0)
            {
                Write_Asscociation_Rules(mask, n, S);
            }
        }
        #endregion
        #region 2
        ///////////////////////////////////////////////////////////////////                
        private int Get_Next_Association_Rule(int[] mask, int n)
        {
            int i;
            for (i = 0; ((i < n) && (mask[i] > 0)); ++i)
            {
                mask[i] = 0;
            }

            if (i < n)
            {
                mask[i] = 1;
                return 1;
            }
            return 0;
        }
        #endregion
        ///////////////////////////////////////////////////////////////////               
        private void Write_Asscociation_Rules(int[] mask, int n, String S)
        {
            #region Determine Association Rules
            int i;
            String Ant = String.Empty, Con = String.Empty;
            String A = String.Empty;
            String C = String.Empty;

            for (i = 0; i < n; ++i)
            {
                if (mask[i] > 0)
                {
                    Ant += S[i].ToString();
                }
            }
            for (i = 0; i < Ant.Length; i++)
            {
                S = S.Replace(Ant[i].ToString(), ""); // remove each character of Ant from S, 
            }
            Con = S; // now the trimmed S becomes Conequent.                        
            //S = Ant + " --> " + Con + Environment.NewLine;
            //txt_Display.AppendText(S);

            for (i = 0; i < Ant.Length; i++)
            {
                A += H[Ant[i].ToString()].ToString() + DLMT;
            }
            A = A.Substring(0, A.Length - 1);

            for (i = 0; i < Con.Length; i++)
            {
                C += H[Con[i].ToString()].ToString() + DLMT;
            }
            if (C.Length > 1)
                C = C.Substring(0, C.Length - 1);
            else // Consequent is a zero length item.. (Ignor it)
                return;

            //S = A + "-->" + C + Environment.NewLine;                        
            //txt_Display.AppendText(S);

            #endregion

            #region Store all Assoc.Rules in Hashtable
            #region Local Variables for Measures Calcualtion.
            String Rule = A + Comma + C;
            Double Supp_Ant = double.Parse(FI[A].ToString());
            Double Supp_Con = double.Parse(FI[C].ToString());
            Double Numerator = 0.0;
            Double Denominator = 0.0;
            Double F11 = Freq;
            Double F1_ = Supp_Ant;
            Double F10 = F1_ - F11;
            Double F_1 = Supp_Con;            
            Double F01 = F_1 - F11;           
            Double F0_ = TotalRows - F1_;
            Double F_0 = TotalRows - F_1;
            Double F00 = F_0 - F10; 
            #endregion

            int Stop_It = 4;
            if ((F10 == 0) && (F01 == 0))
                Stop_It = 0;



            Double Support = (Freq / TotalRows);
            Double Confidenc = Freq / Supp_Ant;
                    

            //Leverage(A and C) = P(A and C) - (P(A)P(C))
            Double Leverage = (Supp_Ant / TotalRows) * (Supp_Con / TotalRows);
            Leverage = Support - Leverage;


            // Lift(A and C) = Lift(C and A) = Conf(A  C)/Supp(C) = Conf(C  A)/Supp(A) = P(A and C)/(P(A)P(C)).            
            Double Lift = (Confidenc / (Supp_Con / TotalRows));

            // All-Confidence(E) = Supp(E) / Max(Supp(e element of E))  
            S = (A + DLMT + C);
            String[] Arr = S.Split(DLMT.ToCharArray());
            Double elem = 0, maxElem = 0;
            for (i = 0; i < Arr.Length; i++)
            {
                elem = double.Parse(FI[Arr[i]].ToString());
                if (elem > maxElem)
                    maxElem = elem;
            }
            Double AllConfidenc = Freq / maxElem;

            
            // Correlation = ((N)(F11)-(F1+)(F+1)) / sqrt((F1+)(F+1)(F0+)(F+0))
            Numerator = (TotalRows * F11) - (F1_  * F_1);
            Denominator = (F1_ * F_1 * F0_ * F_0);
            Double Correlation = Numerator / Math.Sqrt(Denominator);
 
            // Odds Ratio = (F11)(F00) / (F10)(F01)
            Double OddsRatio = (F11 * F00) / (F10  * F01);             

            // Kappa = [ N(F11) + N(F00) - (F1+)(F+1) - (F0+)(F+0) ] / [sqr(N) - (F1+)(F+1)-(F0+)(F+0)]
            Numerator = ( TotalRows * (F11 + F00) - (F1_ * F_1) - (F0_ * F_0));
            Denominator = (TotalRows*TotalRows ) - (F1_ * F_1)-(F0_ * F_0);
            Double Kappa = Numerator / Denominator;

            // Interest
            Double Interest = ((TotalRows * F11) / (F1_ * F_1));

            // Cosine (IS) = (F11)/ [Sqrt(F1+)(F+1))]
            Double Cosine_IS = Freq / (Math.Sqrt(Supp_Ant * Supp_Con));

            // Piatetsky-Shapiro
            Double Piatetsky_Shapiro = (F11/ TotalRows ) - ((F1_*F_1)/(TotalRows * TotalRows));

            // Collective Strength
            Numerator = (F11 + F00) * (TotalRows - (F1_* F_1) - (F0_* F_0) );
            Denominator = ((F1_ * F_1) + ( F0_*F_0)) * ( TotalRows - F11 - F00) ;
            Double Collective_Strength = Numerator / Denominator;
                       
            
            // Jaccard = [F11] / [(F1+) + (F+1) - (F11)]
            Double Jaccard = F11 / (F1_ + F_1 - F11);

            
            // Asymmetric Objective Measures..

            // J_Measure  
            Numerator = (F11 /TotalRows) * Math.Log ((TotalRows * F11) / (F1_ * F_1) );
            Denominator = (F10 / TotalRows) * Math.Log( (TotalRows * F10) / (F1_ * F_0) ); 
            Double J_Measure = Numerator + Denominator;
            
            // Gini Indx 
            Numerator = (((F11 / F1_) * (F11 / F1_)) + ((F10 / F1_) * (F10 / F1_)));
            Numerator = (F1_ / TotalRows) * Numerator - (F_1 / TotalRows) * (F_1 / TotalRows);
            Denominator = (((F01 / F0_) * (F01 / F0_)) + ((F00 / F0_) * (F00 / F0_))); ;
            Denominator = (F0_ / TotalRows) * Denominator - (F_0 / TotalRows);
            Double Gini_Index = Numerator + Denominator;

            // Laplace = (F11 + 1) / F1+ + 2);
            Double Laplace = (F11 + 1)/(F1_ + 2);
            
            // Conviction(A and C)  = (1-Supp(C))/(1-Conf(A and C)) 
            Numerator = (F1_ * F_0);
            Denominator = (TotalRows * F10);
            Double Conviction = Numerator / Denominator;            

            // Certainity Factor = [(F11 / F1+) - (F+1/N)] / [1- (F+1/N)] 
            Numerator = (F11 / F1_) - (F_1/TotalRows) ;
            Denominator = 1 - (F_1/TotalRows);             
            Double Certainity_Factor = Numerator / Denominator;

            // Added Value = (F11/F1+) - (F+1/N)
            Double Added_Value = ((F11 / F1_) - (F_1 / TotalRows));


            //////////////////////////////////////////////////////////////////////
            String All_Measures = Support.ToString() + Comma + Confidenc.ToString() + Comma;  
            All_Measures += Leverage.ToString() + Comma + AllConfidenc.ToString() + Comma;
            All_Measures += Correlation.ToString() + Comma + OddsRatio.ToString() + Comma + Kappa.ToString() + Comma;
            All_Measures += Interest.ToString() + Comma + Cosine_IS.ToString() + Comma + Piatetsky_Shapiro.ToString() + Comma;
            All_Measures +=  Collective_Strength.ToString() + Comma + Jaccard.ToString() + Comma;

            // Asymmetric Objective Measures..
            All_Measures += J_Measure.ToString() + Comma + Gini_Index.ToString() + Comma + Laplace.ToString() + Comma;
            All_Measures += Conviction.ToString() + Comma + Certainity_Factor.ToString() + Comma + Added_Value.ToString(); 

           // String[] Msr = All_Measures.Split(Comma.ToCharArray());
           // Double Measure = Double.Parse(Msr[cbo_Measure.SelectedIndex]);
           // if (Measure >= Threshold)   {   
                // decode each element of Antecedent
                Arr = A.Split(DLMT.ToCharArray());
                for (i = 0; i < Arr.Length; i++)
                {
                    AR_Lines += Codes[int.Parse(Arr[i].ToString())] + DLMT;
                }
                AR_Lines = AR_Lines.Substring(0, AR_Lines.Length - 1);
                AR_Lines += Comma; // separate Ant from Con

                // decode each element of Consequent
                Arr = C.Split(DLMT.ToCharArray());
                for (i = 0; i < Arr.Length; i++)
                {
                    AR_Lines += Codes[int.Parse(Arr[i].ToString())] + DLMT;
                }
                AR_Lines = AR_Lines.Substring(0, AR_Lines.Length - 1);

                // Append all of the measures 
                AR_Lines += Comma + All_Measures;
                AR_Lines = AR_Lines +Environment.NewLine;                                
            //}

            
            #endregion

        }
       
        /// /////////////////////////////////////////////////////////////////////////////////////
        #endregion
        
        #region Display Hashtabl Content
        private String Display_AR_FI(Hashtable T)
        {
            txt_Display.Clear();
            IDictionaryEnumerator ID = T.GetEnumerator();
            while (ID.MoveNext())
            {
                txt_Display.AppendText(ID.Key.ToString() + " = " + ID.Value.ToString() + Environment.NewLine);                                
            }

            return "Completed";
        }

        #endregion

        #region CreateSubsets
        List<T[]> CreateSubsets<T>(T[] originalArray)
        {
            List<T[]> subsets = new List<T[]>();

            for (int i = 0; i < originalArray.Length; i++)
            {
                int subsetCount = subsets.Count;
                subsets.Add(new T[] { originalArray[i] });

                for (int j = 0; j < subsetCount; j++)
                {
                    T[] newSubset = new T[subsets[j].Length + 1];
                    subsets[j].CopyTo(newSubset, 0);
                    newSubset[newSubset.Length - 1] = originalArray[i];
                    subsets.Add(newSubset);
                }
            }

            return subsets;
        }
        #endregion

        #region Generate_Freq_Items
        private void Generate_Freq_Items(String originalString)
        {
            List<string[]> subsets = CreateSubsets(originalString.Split(Comma.ToCharArray()));
            String S = String.Empty;
            int i = 0;
            foreach (string[] subset in subsets)
            {            
                S = string.Join(DLMT, subset);
                //txt_Display.AppendText(S + Environment.NewLine);
                // Update Frequent Items Hashtable...
                if (FI.Contains(S) == true)
                {
                    i = int.Parse(FI[S].ToString()) + 1;
                    FI[S] = i;
                }
                else
                {
                    FI.Add(S, 1);
                }

            }
        }
        #endregion

        #region Generate_FI_from_Dataset
        private Double Generate_FI_from_Dataset()
        {
            String S = String.Empty;
            Double Total_Rows = 0;
            StreamReader SR = File.OpenText(CMN.DigitizedSheet);
            SR.ReadLine(); // Header Line...

            while (!SR.EndOfStream)
            {
                S = SR.ReadLine();
                Generate_Freq_Items(S);
                Total_Rows++;
            }
            SR.Close();
            SR.Dispose();
            return Total_Rows;
        }
        #endregion               
      
        #region Write_FI
        private String Write_FI()
        {
            String Line = String.Empty;
            int i = 0;
            Hashtable Codes = Load_Hashtable_File(CMN.Codes);
            File.Delete(CMN.FI_Sheet);
            StreamWriter SW = File.AppendText(CMN.FI_Sheet);
            Line = "Item" + Comma + "Frequency";
            SW.WriteLine(Line);
            
            IDictionaryEnumerator ID = FI.GetEnumerator();
            while (ID.MoveNext())
            {
                Line = String.Empty; 
                String[] Arr = ID.Key.ToString().Split(DLMT.ToCharArray());
                for (i = 0; i < Arr.Length; i++)
                {
                    Line += Codes[int.Parse(Arr[i].ToString())].ToString() + DLMT ;
                }
                Line = Line.Substring(0, Line.Length - 1);
                Line += Comma + ID.Value.ToString();
                SW.WriteLine(Line);
            }
            SW.Close();
            SW.Dispose();
            return CMN.FI_Sheet + " written";
        }

        private void btn_Write_FI_Click(object sender, EventArgs e)
        {
            txt_Display.Text = Write_FI();
        }


        #endregion
              
        #region Simplify AR & FI
        private String Simplify(String S)
        {
            int i = 0;
            String Ret = String.Empty;
            Boolean Start = true; 
            for (i = 0; i < S.Length - 1; i++) 
            {
                if (S[i] == '(')
                    Start  = false;
                else if (S[i] == ')')
                    Start = true;
                else if (Start == true)
                {
                    Ret += S[i];
                }
            }            
            return Ret;
        }

        #region Simplify_AR
        private String Simplify_AR()
        {
            String Line = String.Empty;
            int i = 0;
            StreamReader SR = File.OpenText(CMN.AR_Sheet);
            File.Delete(CMN.AR_Simple);
            StreamWriter SW = File.AppendText(CMN.AR_Simple);
            SW.WriteLine(SR.ReadLine()); // Header.
            while (!SR.EndOfStream)
            {
                String[] Arr = SR.ReadLine().Split(Comma.ToCharArray());
                Line  = Simplify(Arr[0]) + Comma ;
                Line += Simplify(Arr[1]) + Comma;
                for (i = 2; i < Arr.Length; i++)
                    Line += Arr[i] + Comma;
                Line = Line.Substring(0, Line.Length - 1); //remove last comma
                SW.WriteLine(Line);
            }
            SR.Close();
            SR.Dispose();
            SW.Close();
            SW.Dispose();

            return "Done!" + CMN.AR_Simple;
        }

        private void btn_Simplify_AR_Click(object sender, EventArgs e)
        {
            txt_Display.Text = Simplify_AR();
        }
        #endregion

        #region Simplify_FI()
        private String Simplify_FI()
        {
            String Line = String.Empty;            
            StreamReader SR = File.OpenText(CMN.FI_Sheet);
            File.Delete(CMN.FI_Simple);
            StreamWriter SW = File.AppendText(CMN.FI_Simple);
            SW.WriteLine(SR.ReadLine()); // Header.
            while (!SR.EndOfStream)
            {
                String[] Arr = SR.ReadLine().Split(Comma.ToCharArray());
                Line = Simplify(Arr[0]) + Comma + Arr[1];                 
                SW.WriteLine(Line);
            }
            SR.Close();
            SR.Dispose();
            SW.Close();
            SW.Dispose();

            return "Done!" + CMN.FI_Simple;
        }

        private void btn_Simplify_FI_Click(object sender, EventArgs e)
        {
            txt_Display.Text = Simplify_FI();
        }
        #endregion
        #endregion

        #region Apply_Ordering
        private String Apply_Ordering()
        {
            int j = 0;            
            Double V = 0.0;
            String Ant = String.Empty;
            String Line = String.Empty;
            Hashtable[] h_Orders = new Hashtable[18];
            for (j=0; j<h_Orders.Length; j++)
              h_Orders[j] = new Hashtable(); // set to non-null reference..

            StreamReader SR = File.OpenText(CMN.AR_Simple);
            String[] Arr =  SR.ReadLine().Split(Comma.ToCharArray()); // Header...
            Line = "Feature,";
            for (j = 2; j < Arr.Length; j++)
                Line += Arr[j] + Comma ;
            Line = Line.Substring(0, Line.Length - 1); // remove last comma
            
            while (!SR.EndOfStream)
            {
               Arr = SR.ReadLine().Split(Comma.ToCharArray());
                Ant = Arr[0];
                if (Ant.Length == 1) // single Antecedent ony..
                {
                    for (j = 0; j < Arr.Length-2; j++)
                    {
                        if (h_Orders[j].Contains(Ant) == false)
                        {
                            h_Orders[j].Add(Ant, Arr[j+2]);
                        }
                        else
                        {
                            V = Double.Parse(h_Orders[j][Ant].ToString());
                            V += Double.Parse(Arr[j+2]);
                            h_Orders[j][Ant] = V;
                        }
                    }                    
                }
            }
            SR.Close();
            SR.Dispose();
           
            ///////////////////////////////////
            File.Delete ( CMN.Orders);
            
            StreamWriter SW = File.AppendText(CMN.Orders);
            SW.WriteLine(Line); // HEADER 
            IDictionaryEnumerator ID = h_Orders[0].GetEnumerator();
            while (ID.MoveNext())
            {
                Line = ID.Key.ToString();
                for (j = 0; j < h_Orders.Length; j++)
                {
                    Line += Comma + h_Orders[j][ID.Key] ;
                }
                SW.WriteLine(Line);                
            }
            SW.Close();
            SW.Dispose();
            
            return "Ordering Files Done! ";
        }       

        private void btn_Apply_Ordering_Click(object sender, EventArgs e)
        {
            txt_Display.Text = Apply_Ordering();
        }
        #endregion
        
        #region Proceed for All of the Operations
        private void btn_GO_Click(object sender, EventArgs e)
        {
            Digitize_Text_Matrix(); // temporary off
            btn_Generate_FI_Click(null, null);
            btn_Generate_AR_Click(null, null);
            Simplify_AR();
            txt_Display.Text = Apply_Ordering();
        }
        #endregion

        #region Load FI
        private void btn_Load_FI_Click(object sender, EventArgs e)
        {
            FI = Load_Hashtable_File(CMN.FI);
            txt_Display.Text = FI.Count.ToString() + " FI generated and saved to FI.bin";
        }
        #endregion
        
        #region DataImport_at_FixedLength
        private void btn_DataImport_at_FixedLength_Click(object sender, EventArgs e)
        {
            String Path = String.Empty;
            DirectoryInfo dir = new DirectoryInfo("D:\\ERP_LXP");
            FileInfo[] fi = dir.GetFiles("*.txt");
            foreach (FileInfo f in fi)
            {
                Path = f.FullName.ToString();
                txt_Display.Text = ImportDataImport_at_FixedLength(Path);
            }
        }


        private string ImportDataImport_at_FixedLength(String Path)
        {
            int[] Pos = new int[600];
            int j = 0, k=0, x=0,y=0;
            String Str = String.Empty;
            String subS = String.Empty;
            String newStr = String.Empty;

            String OutPath = Path.Replace(".txt", ".csv");
            File.Delete(OutPath);
            StreamReader R = File.OpenText(Path);
            StreamWriter SW = File.AppendText(OutPath);

            Str = R.ReadLine();
            int i = 0;
            Boolean SpaceFound = false;
            Boolean CharFound = false;

            for (i = 1; i < Str.Length; i++)
            {
                if (Str[i] == ' ')
                {
                    SpaceFound = true;
                    x = i;
                }
                else
                {
                    CharFound = true;
                    y = i;
                }

                if ((SpaceFound == true) && (CharFound == true) && (y>x))
                {
                    Pos[j] = i-1;
                    j++;
                    SpaceFound = false;
                    CharFound = false;
                }
            }
            int maxPos = j;

            // multiple spaces into single tab between two columns
            String[] Arr = Str.Split(" ".ToCharArray());
            Str = String.Empty;
            for (i = 0; i < Arr.Length; i++)
            {
                if (Arr[i].Trim().Length > 1)
                 Str += Arr[i] + "\t";
            }
            Str = Str.Substring(0, Str.Length - 1);
            SW.WriteLine(Str); // header 

           
            // start processing data other than header
            while (!R.EndOfStream)
            {
                Str = R.ReadLine();
                Str = Str.Replace('\t', ' ');
                if (Str.Trim().Length > 2)
                {

                    newStr = String.Empty;
                    i = 0;
                      for (j = 0; j < maxPos; j++)
                        {
                            int sec = (Pos[j] >= Str.Length) ? (Str.Length-1) : Pos[j];
                            if (sec >= i)
                            {
                                subS = Str.Substring(i, sec - i + 1);
                                newStr += subS + "\t";
                                i = Pos[j] + 1;
                            }
                            if (Str.Length < Pos[j+1])
                            {
                                j = maxPos;
                            }
                        }
                      if ((Pos[j - 1] > 0) && (Str.Length > Pos[j - 1] - 1))
                      {
                          subS = Str.Substring(i, Str.Length - Pos[j - 1] - 1);
                          newStr += subS;
                      }

                    // if short column then append column with no data
                    Arr = newStr.Split("\t".ToCharArray());
                    for (k =0; k<=(maxPos - Arr.Length); k++)
                    {
                        newStr += "\t ";
                    }

                    // write the processed line
                    SW.WriteLine(newStr);
                }
            }
                       
            R.Close();
            R.Dispose();
            SW.Close();
            SW.Dispose();
            return  "Done";
        }
        #endregion


        #region Combine_All_File
        private void btn_Combine_All_File_Click(object sender, EventArgs e)
        {
            String Path = String.Empty;
            String OutPath = "D:\\allFiles.txt";
            File.Delete(OutPath);
            
            DirectoryInfo dir = new DirectoryInfo("D:\\ERP_LXP");
            FileInfo[] fi = dir.GetFiles("*.txt");
            foreach (FileInfo f in fi)
            {
                Path = f.FullName.ToString();
                // All data ...
                // txt_Display.Text = Combine_All_Files(Path, OutPath);
                
                // only header...
                //txt_Display.Text = Combine_All_Files(Path, OutPath, 0);
                
                // All data except header
                txt_Display.Text = Combine_All_Files(Path, OutPath , "");

            }

        }

        // All data of the files are extracted and combined to single file
        private String Combine_All_Files(String Path, String OutPath)
        {
            String Str = String.Empty;
            
            StreamReader R = File.OpenText(Path);
            StreamWriter SW = File.AppendText(OutPath);

            Str += R.ReadToEnd();
            SW.WriteLine(Str);
            
            R.Close();
            R.Dispose();
            SW.Close();
            SW.Dispose();
            return "Done";
        }

        // only header of the files are extracted and combined to single file
        private String Combine_All_Files(String Path, String OutPath, int option)
        {
            String Str = String.Empty;

            StreamReader R = File.OpenText(Path);
            StreamWriter SW = File.AppendText(OutPath);

            Str += R.ReadLine();
            SW.WriteLine(Str);

            R.Close();
            R.Dispose();
            SW.Close();
            SW.Dispose();
            return "Done";
        }

        // All data ecept header of the files are extracted and combined to single file
        private String Combine_All_Files(String Path, String OutPath, String option)
        {
            String Str = String.Empty;

            StreamReader R = File.OpenText(Path);
            StreamWriter SW = File.AppendText(OutPath);
            R.ReadLine(); // header

            while (!R.EndOfStream)
            {
                Str += R.ReadLine();
            }
             SW.WriteLine(Str);

            R.Close();
            R.Dispose();
            SW.Close();
            SW.Dispose();
            return "Done";
        }


        #endregion






    }
}