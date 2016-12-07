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

namespace AR_4_NonBinary
{
    class COMMON
    {
        #region Local Variables                
        public String Result_Folder = Application.StartupPath.ToString() + "\\Results\\";
        public String OrigionalSheet = Application.StartupPath.ToString() + "\\Results\\1_OrigionalSheet.csv";
        public String DigitizedSheet = Application.StartupPath.ToString() + "\\Results\\2_DigitizedSheet.csv";
        public String DiscretizedSheet = Application.StartupPath.ToString() + "\\Results\\2_DiscretizedSheet.csv";
        public String FI_Sheet = Application.StartupPath.ToString() + "\\Results\\3_FI_Sheet.csv";
        public String AR_Sheet = Application.StartupPath.ToString() + "\\Results\\4_AR_Sheet.csv";
        public String FI_Simple = Application.StartupPath.ToString() + "\\Results\\3_FI_Simple.csv";
        public String AR_Simple = Application.StartupPath.ToString() + "\\Results\\4_AR_Simple.csv";
        public String Orders = Application.StartupPath.ToString() + "\\Results\\5_Orders.csv";
        
        public String Codes = Application.StartupPath.ToString() + "\\Results\\Codes.bin";
        public String FI = Application.StartupPath.ToString() + "\\Results\\FI.bin";
        public String AR = Application.StartupPath.ToString() + "\\Results\\AR.bin";        
        #endregion
    }

    


}
