﻿using System.ComponentModel.DataAnnotations;

namespace MyWebApplication.Models.Forms;

public class AccountDetailsAddressInfoModel
{

	[Display(Name = "Address line 1", Prompt = "Enter your address line ", Order = 0)]
	[Required(ErrorMessage = "Address is required")]
	[DataType(DataType.Text)]
	[MinLength(2, ErrorMessage = "Address is required")]
	public string Addressline_1 { get; set; } = null!;

	[Display(Name = "Address line 2", Prompt = "Enter your second address line", Order = 1)]
	public string? Addressline_2 { get; set; }

	[Display(Name = "Postal Code", Prompt = "Enter your postal code", Order = 2)]
	[Required(ErrorMessage = "Postal code is required")]
	[DataType(DataType.PostalCode)]
	[MinLength(2, ErrorMessage = "Postal code is required")]

	public string PostalCode { get; set; } = null!;

	[Display(Name = "City", Prompt = "Enter your City", Order = 3)]
	[Required(ErrorMessage = "City is required")]
	[DataType(DataType.Text)]
	[MinLength(2, ErrorMessage = "City is required")]
	public string City { get; set; } = null!;
}
