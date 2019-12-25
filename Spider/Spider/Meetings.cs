using OrenburgTourismFM.Model;
using System.Collections.Generic;
using System.Text;
using HtmlAgilityPack;
using System;
using Spider.Spider;
using OrenburgTourismFM.Models;

namespace Spider
{
    public class Meetings
    {
        public static string Url = "https://www.2do2go.ru";
        /// <summary>
        /// Метод позволяет получить список ближайших (по дате) <see cref="Meeting"/> с сайта www.2do2go.ru
        /// </summary>
        /// <returns>Список событий</returns>
        public static List<Meeting> GetMeetings(int offset = 0, DateTime? date = null)
        {
            List<Meeting> meetings = new List<Meeting>();
            HtmlDocument doc = new HtmlDocument();

            string requestUrl = Url + $"/oren/events?offset={offset}&date=";
            if(date != null)
            {
                requestUrl += $"{date.Value.Year}-{date.Value.Month}-{date.Value.Day}";
            }
            doc.LoadHtml(Util.GetRequest(requestUrl));

            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//div[@class='cards-grid']/div/a");
            if(nodes != null)
            {
                foreach(HtmlNode node in nodes)
                {
                    try
                    {
                        string meetingUrl = node.Attributes["href"].Value;

                        HtmlDocument meetingDocument = new HtmlDocument();
                        meetingDocument.LoadHtml(Util.GetRequest(Url + meetingUrl));

                        // Название и фотография события
                        HtmlNode meetingInfo = meetingDocument.DocumentNode.SelectSingleNode("//div[@class='entity-info']");
                        string title = meetingInfo.SelectSingleNode("//div/div[@class='entity-info_name']/div").InnerText;
                        string photoUrl = Url + meetingInfo.SelectSingleNode("//div/button/img").Attributes["src"].Value;
                        photoUrl = photoUrl.Replace("_w100_h140", "");

                        // Описание события
                        HtmlNodeCollection descriptionNodes = meetingDocument.DocumentNode.SelectNodes("//div[@class='content_view content_view__text']/p");
                        StringBuilder descriptionBuilder = new StringBuilder();
                        foreach (HtmlNode descriptionNode in descriptionNodes)
                        {
                            descriptionBuilder.Append(descriptionNode.InnerText);
                        }

                        // Дата начала события
                        HtmlNode timerNode = meetingDocument.DocumentNode.SelectSingleNode("//div[@class='timer-block_header']");
                        string dateMeeting =
                            timerNode.SelectSingleNode("//div[@class='timer-block_date']").InnerText
                            + " " +
                            timerNode.SelectSingleNode("//div[@class='timer-block_time']").InnerText;

                        // Цена билета
                        HtmlNode meetingCost = meetingDocument.DocumentNode.SelectSingleNode("//div[@class='sidebar-info_row']/h3[text()='Цены на билеты:']");
                        string cost = meetingCost.NextSibling.InnerText;

                        // Место проведения события
                        HtmlNode meetingPlace = meetingDocument.DocumentNode.SelectSingleNode("//a[@class='media-preview_description']");

                        string placeURL = meetingDocument.DocumentNode.SelectSingleNode("//a[@class='media-preview_name']").Attributes["href"].Value;

                        Place place = Places.GetPlace(Url + placeURL);

                        place.Street = meetingPlace.InnerText;

                        Meeting meeting = new Meeting
                        {
                            Name = title,
                            PhotoSource = photoUrl,
                            Description = descriptionBuilder.ToString(),
                            Date = dateMeeting,
                            Cost = cost,
                            Place = place
                        };
                        meetings.Add(meeting);
                    }catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return meetings;
        }
    }
}
