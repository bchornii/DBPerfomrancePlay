namespace PerfDemo.DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GitHubUser")]
    public partial class GitHubUser
    {
        [Key]
        public int DBId { get; set; }

        public int Id { get; set; }

        public string Login { get; set; }

        public string AvatarUrl { get; set; }

        public string GravatarId { get; set; }

        public string Url { get; set; }

        public string HtmlUrl { get; set; }

        public string FollowersUrl { get; set; }

        public string FollowingUrl { get; set; }

        public string GistsUrl { get; set; }

        public string StarredUrl { get; set; }

        public string SubscriptionsUrl { get; set; }

        public string OrganizationsUrl { get; set; }

        public string ReposUrl { get; set; }

        public string EventsUrl { get; set; }

        public string ReceivedEventsUrl { get; set; }

        public string Type { get; set; }

        public bool SiteAdmin { get; set; }

        public DateTime? GrabDate { get; set; }
    }
}
