using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zsebi2.Models
{
	public class Article
	{
		public int ID { get; set; }
		public string Title { get; set; }
		public string HtmlBody { get; set; }
		public DateTime PublishDate { get; set; }
		public string ThumbnailFileName { get; set; }	
		public string Excerpt { get; set; }
		public string MoreInfoUrl { get; set; }
	}
}
