using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace mvvm.Models
{
    public class Model
    {
        public string[] Files { get; set; }
        public ImageSource Path { get; set; }

        public string Name { get; set; }
    }
}
