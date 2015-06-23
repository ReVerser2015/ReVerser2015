using System;
using System.Collections.Generic;
using System.Text;

namespace ReVerser2015.ParseAPI.HTML
{
   partial class Trace
    {
       partial void WriteLineIntern(string message,string category)
       {
           System.Diagnostics.Debug.WriteLine(message,category);
       }
    }
}
