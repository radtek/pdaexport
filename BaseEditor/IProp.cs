using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BaseEditor
{
    public interface IProp
    {
        void MakeSQLView(ref ListView sqlView);
        void PropAdd(ref ListView propView); // add data to view
        void PropCreate(ref ListView propView); //тоже что и PropAdd но очищает view
    }
}
