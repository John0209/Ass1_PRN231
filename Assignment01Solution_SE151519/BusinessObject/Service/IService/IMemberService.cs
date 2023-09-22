using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Service.IService
{
	public interface IMemberService
	{
		public IEnumerable<Member> GetMembers();
		public bool UpdateMember(Member member);
		public void DeleteMember(Member member);
		public Member GetMemberById(int id);
		public void AddMember(Member member);
		public Member CheckLogin(string email, string password);
		public IEnumerable<Member> SearchMember(string searchs);
	}
}
