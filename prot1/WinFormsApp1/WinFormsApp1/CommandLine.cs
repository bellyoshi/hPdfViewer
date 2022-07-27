using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class CommandLine
    {
        public static void GetFileAndOpen()
        {
            var cmds = System.Environment.GetCommandLineArgs();
            if (cmds.Length == 2)
            {
                var filename = cmds[1];
                WorkPDF.ThisWorkPDF.Open(filename);
            }
        }
    }
}
