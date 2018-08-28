using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDIApplicationExample
{
    public class SDIApplication : WindowsFormsApplicationBase// trebuie sa-i faci mostenirea asta daca vrei sa faci SDI App
    {
        //asta trebuie  sa fie un singleton de aceea campul este static 
        private static SDIApplication _sdiApplicationInstance = null;

        public SDIApplication()//aici setezi shutdownmode-ul si sa verifici sa fie doar o singura instanta iti trebe la SDI App
        {
            IsSingleInstance = true;
            ShutdownStyle = ShutdownMode.AfterAllFormsClose;
        }
        //pentru Singleton ai doar GET, pentru ca trebuie doar sa-ti returnezi valoarea nu sa o si creezi
        public static SDIApplication SdiInstance
        {
            get
            {
                if (_sdiApplicationInstance == null)
                {
                    _sdiApplicationInstance = new SDIApplication();
                }
                return _sdiApplicationInstance;
            }
        }
        //trebuie sa faci override la metodele astea pentru SDI
        protected override void OnCreateMainForm()
        {
            DocForm.CreateForm();
        }
        protected override void OnStartupNextInstance(StartupNextInstanceEventArgs eventArgs)
        {
            DocForm.CreateForm();
        }
    }
}
