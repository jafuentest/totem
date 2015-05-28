using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DominioTotem.ResponseObject
{

    public class ResponseDataMinuta
    {


        public int Draw { get; set; }

        public int RecordsTotal { get; set; }

        public int RecordsFiltered { get; set; }

        public IEnumerable<string[]> Data { get; set; }


    }
}
