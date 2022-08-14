using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.ComponentModel.Composition.Hosting;

namespace MEFLearning
{
    class Program
    {
        //
        [Export("HistoryBook", typeof(IBookService))]
        //[Import("HistoryBook")]
        public IBookService Service { get; set; }

        static void Main(string[] args)
        {
            Program pro = new Program();
            pro.Compose();
            if (pro.Service != null)
            {
                Console.WriteLine(pro.Service.GetBookName());
            }
            Console.Read();
        }

        private void Compose()
        {
            var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            CompositionContainer container = new CompositionContainer(catalog);
            container.ComposeParts(this);
        }
    }
}
