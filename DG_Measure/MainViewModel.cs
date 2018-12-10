using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DG_Measure
{
    [POCOViewModel()]
    public class MainViewModel
    {
        public void Show()
        {
            var service = this.GetService<IDocumentManagerService>();
            var document = service.CreateDocument("View", null, this);
            document.Show();
        }
    }
}
