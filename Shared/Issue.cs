using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorApp.Shared
{
    public class Issue
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string IssueUrl { get; set; }

        public Issue(string name, string subtitle, string description,  string imagePath, string url)
        {
            Title = name;
            Description = description;
            Subtitle = subtitle;
            ImagePath = imagePath;
            IssueUrl = url;
        }
    }
}
