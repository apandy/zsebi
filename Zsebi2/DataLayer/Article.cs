using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zsebi2.DataLayer
{
	[Table("Articles")]
    public class Article
	{
		public int ID { get; set; }
        
        [MaxLength(50)]
        public string Url { get; set; }

		public string Title { get; set; }

		public string HtmlBody { get; set; }

		public DateTime PublishDate { get; set; }

		[Column("ThumbnailfileName")]
		public string ThumbnailFileName { get; set; }	

		public string Excerpt { get; set; }

		public string MoreInfoUrl { get; set; }
	}
}
