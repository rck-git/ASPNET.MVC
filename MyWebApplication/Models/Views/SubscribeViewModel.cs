﻿using System.ComponentModel.DataAnnotations;

namespace MyWebApplication.Models.Views;

public class SubscribeViewModel
{
	[Required(ErrorMessage ="Enter a valid email.")]
	[EmailAddress]
	[Display(Name = "E-mail address", Prompt = "Your Email")]

	public string Email { get; set; } = null!;
	public bool DailyNewsletter { get; set; }
	public bool AdvertisingUpdates {  get; set; }
	public bool WeekinReview {  get; set; }
	public bool EventUpdates {  get; set; }
	public bool StartupsWeekly { get; set; }
	public bool Podcasts {  get; set; }

}
