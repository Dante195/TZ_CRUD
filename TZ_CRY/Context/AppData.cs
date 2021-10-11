using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TZ_CRY.Model;

namespace TZ_CRY.Context
{
    public static class AppData
    {
        public static LINQEntities db = new LINQEntities();
    }
}
