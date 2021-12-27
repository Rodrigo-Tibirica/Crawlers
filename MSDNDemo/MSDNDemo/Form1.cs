using System;
using System.Net;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace MSDNDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var url = "https://social.msdn.microsoft.com/Forums/pt-BR/home?filter=alltypes$sort=firstpostdesc";
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);

            var htmlDocument = new HtmlAgilityPack.HtmlDocument();
            htmlDocument.LoadHtml(html);

            dataGridView1.Rows.Clear();

            string id = string.Empty;
            string titulo = string.Empty;
            string postagem = string.Empty;
            string exibicao = string.Empty;
            string resposta = string.Empty;
            string link = string.Empty; 

            foreach( HtmlNode node in htmlDocument.GetElementbyId("threadList").ChildNodes)
            {
                if(node.Attributes.Count > 0) 
                {
                    id = node.Attributes["data-threadid"].Value;
                    link = "https://social.msdn.microsoft.com/Forums/pt-BR/" + id;
                    titulo = WebUtility.HtmlDecode(node.Descendants().First(x => x.Id.Equals("threadTitle_" + id)).InnerText);
                    postagem = WebUtility.HtmlDecode( node.Descendants().First(x => x.Attributes["class"] != null && x.Attributes["class"].Value.Equals("lastpost")).InnerText.Replace("\n", "").Replace("  ", ""));
                    exibicao = WebUtility.HtmlDecode(node.Descendants().First(x => x.Attributes["class"] != null && x.Attributes["class"].Value.Equals("viewcount")).InnerText);
                    resposta = node.Descendants().First(x => x.Attributes["class"] != null && x.Attributes["class"].Value.Equals("replycount")).InnerText;

                    if (!string.IsNullOrEmpty(titulo))
                    {
                        dataGridView1.Rows.Add(titulo, postagem, exibicao, resposta, link);
                    }

                }
            }
        }
    }
}