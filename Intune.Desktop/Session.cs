using InTune.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intune.Desktop
{
    public static class Session
    {
        public static User CurrentUser = null;
        public static CommentFormManager CommentFormManager = null;

        public static string GetFormTitle()
        {
            return string.Format("{0}@Intune", Session.CurrentUser.Name);
        }
    }
}
