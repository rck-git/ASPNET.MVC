using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Factories;

public class ResponseFactory
{
	public static ResponseResult Ok()
	{
		return new ResponseResult
		{
			
			Message = "Created successfully",
			StatusCode = StatusCode.OK
		};
	}
	public static ResponseResult Ok(object obj, string? message=null)
	{
		return new ResponseResult
		{
			ContentResult = obj,
			Message =  message ?? "Created successfully",
			StatusCode = StatusCode.OK
		};
	}
	public static ResponseResult Error(string? message = null)
	{
		return new ResponseResult
		{
			Message = message ?? "Failed",
			StatusCode = StatusCode.ERROR
		};
	}
	public static ResponseResult NotFound(string? message = null)
	{
		return new ResponseResult
		{

			Message = message ?? "Not Found",
			StatusCode = StatusCode.NOTFOUND
		};
	}
	public static ResponseResult Exists(string? message = null)
	{
		return new ResponseResult
		{

			Message = message ?? "Already Exists",
			StatusCode = StatusCode.EXISTS
		};
	}
}
