using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zsebi2.DataLayer
{
	[Table("Articles")]
    public class Article
	{
		public int ID { get; set; }

	    [MaxLength(100)]
        public string Url { get; set; }

	    [MaxLength(100)]
        public string Title { get; set; }

		public string HtmlBody { get; set; }

		public DateTime PublishDate { get; set; }

		[Column("ThumbnailfileName")]
		public string ThumbnailFileName { get; set; }	

		public string Excerpt { get; set; }

		public string MoreInfoUrl { get; set; }

	    public string GetUrl()
	    {
	        return string.IsNullOrWhiteSpace(Url) ? ID.ToString() : Url;
	    }
	}
}
