using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lantea.Infrastructure
{
    public class DataContext
    {
        /// <summary>
        /// path of the file provider
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// Connection string of database provider
        /// </summary>
        public string ConnectionStringName { get; set; }
        /// <summary>
        /// query for database provider
        /// </summary>
        public string QueryString { get; set; }
        /// <summary>
        /// start url of the spider provider
        /// </summary>
        public string Url { get; set; }
    }
}
