using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nest;
using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.QueryDsl;
using Elastic.Transport;
using System.Windows.Forms;

using Elastic.Clients.Elasticsearch.Mapping;

using Elasticsearch.Net;
using System.IO;
using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.QueryDsl;

using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;

using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace InsertingDataThroughNet
{   
    public partial class Form1 : Form
    {   
        public Form1()
        {
            InitializeComponent();
            //var indexName = "personobject1";
            var settings = new ConnectionSettings(new Uri("http://localhost:9200"));
            //.DefaultIndex("personobject1"); // Set the default index

            var client = new ElasticClient(settings);

        }
        public class PersonProfile
        {
            public long Id { get; set; }
            public string firstName { get; set; }
            // public string PhoneNumber { get; set; }
            public string lastName { get; set; }

            // public DateTime createdDate { get; set; }
            [Date(Format = "dd-MM-yyyy", Index = true)]
            public DateTime createdDate { get; set; }
        }
        public class PersonProfile2
        {
            public int  Id { get; set; }
            public string firstName { get; set; }
            // public string PhoneNumber { get; set; }
            public string lastName { get; set; }

            // public DateTime createdDate { get; set; }
            [Date(Format = "dd-MM-yyyy", Index = true)]
            public DateTime createdDate { get; set; }
        }
        int idupdated = 0;
        static int NewNumber()
        {
            Random a = new Random(); // replace from new Random(DateTime.Now.Ticks.GetHashCode());
                                     // Since similar code is done in default constructor internally
            List<int> randomList = new List<int>();
            int MyNumber = 0;
            MyNumber = a.Next(0, 1000);
            if (!randomList.Contains(MyNumber))
            {
                randomList.Add(MyNumber);

            }
            return randomList.Last();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            var scrollTime = "5m"; // Scroll time set to 5 minutes
            var pageSize = 1000; // Number of documents to retrieve per scroll batch
                                 //var indexName = "personobject1";
            var settings = new ConnectionSettings(new Uri("http://localhost:9200"));
            //.DefaultIndex("personobject1"); // Set the default index

            var client = new ElasticClient(settings);
            var totalCount = 0;
            var dailyCounts = new Dictionary<DateTime, int>();

            var searchResponse = client.Search<PersonProfile>(s => s
                 .Index("myindex11")
                .Scroll(scrollTime) // Set the scroll time
                .Size(pageSize) // Set the size of each scroll batch
                
                .Query(q => q
                    .Bool(b => b
                        .Must(m => m
                            .Match(mt => mt
                                .Field(p => p.createdDate)
                                .Query("CreatedDate")
                            ),
                            m => m
                            .DateRange(dr => dr
                                .Field(p => p.createdDate) // Assuming you have a "Date" field in ElasticsearchProject
                                .GreaterThanOrEquals(new DateTime(2023, 05, 17))
                                .LessThanOrEquals(new DateTime(2023, 05, 21))
                            )
                        )
                    )
                )
            );

            while (searchResponse.Documents.Any())
            {
                // Process the documents in the current scroll batch
                foreach (var document in searchResponse.Documents)
                {
                    var date = document.createdDate.Date; // Extract the date part only
                    if (dailyCounts.ContainsKey(date))
                        dailyCounts[date]++;
                    else
                        dailyCounts[date] = 1;
                }

                // Scroll to the next batch
                var scrollId = searchResponse.ScrollId;
                searchResponse = client.Scroll<PersonProfile>(scrollTime, scrollId);
            }

            // Clear the scroll
            client.ClearScroll(c => c.ScrollId(searchResponse.ScrollId));

            // Write the daily counts to a text file
            using (var writer = new StreamWriter("daily_counts.txt"))
            {
                foreach (var entry in dailyCounts)
                {
                    var line = $"{entry.Key:d} {entry.Value}";
                    writer.WriteLine(line);
                }
            }

            Console.WriteLine("Daily counts written to 'daily_counts.txt'");

        }
        private void createIndex()
        {
            var settings = new ConnectionSettings(new Uri("http://localhost:9200"));
            //.DefaultIndex("personobject1"); // Set the default index

            var client = new ElasticClient(settings);
            client.Indices.Create("myindex11", c => c
          .Map<PersonProfile>(p => p
         .AutoMap()));
            var createIndexResponse = client.Indices.Create("myprofile11", c => c
        .Map<PersonProfile>(m => m
            .Properties(p => p
                .Text(t => t
                    .Name(doc => doc.firstName)
                )
                .Text(t => t
                    .Name(doc => doc.lastName)
                )
                .Number(n => n
                    .Name(doc => doc.Id)
                    .Type(NumberType.Integer)
                )
                .Number(n => n
                    .Name(doc => doc.createdDate)
                    .Type(NumberType.Integer)
                    //.Format("epoch_second")
                )
            // Add more field definitions as needed...
            )
        )
    );

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //var indexName = "personobject1";
            var settings = new ConnectionSettings(new Uri("http://localhost:9200"));
            //.DefaultIndex("personobject1"); // Set the default index

            var client = new ElasticClient(settings);
            var createIndexResponse = client.Indices.Create("myindex11", c => c
              .Map<PersonProfile>(m => m
              .AutoMap()

               )
              
              );
            createIndex();
            //====================================================
            /*var createIndexResponse = client.Indices.Create(indexName, c => c
                .Map<Person1>(m => m
                    .Properties(p => p
                        .Integer(d => d
                            .Name(doc => doc.DateField)
                        )
                    // More field definitions...
                    )
                )
            );*/


        }
        private void clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            createIndex();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var settings = new ConnectionSettings(new Uri("http://localhost:9200"));
            //.DefaultIndex("personobject1"); // Set the default index

           
            var personprofile = new PersonProfile
            {
                Id = NewNumber(),
                //Id =1,
                firstName = textBox1.Text,
                // PhoneNumber = textBox2.Text,

                //PostDate = new DateTime(),
                lastName = textBox2.Text,



                //createdDate = new DateTime(2009, 11, 15),
                //DateTime.ParseExact("24/01/2013", "dd/MM/yyyy");
                createdDate = DateTime.ParseExact(textBox3.Text,
              "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                //var ttt =DateTime.ParseExact(textBox3.Text, "MM-dd-yyyy", null).ToString("yyyy-MM-dd'T'HH:mm:ss"),
                //createdDate = new DateTime(05-18-2023)

            };
            var client = new ElasticClient(settings);
            var indexResponse = client.Index(personprofile, p => p.Index("myindex11"));

            clear();

        }
    }
}
