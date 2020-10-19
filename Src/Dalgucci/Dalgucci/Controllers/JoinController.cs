using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Dalgucci.Controllers
{
	public class JoinController : Controller
	{
		[HttpPost]
		public string Join( string MemberID, string Password, string NickName, string Email )
		{
			return MemberID + Password + NickName + Email;
		}
	}
}
