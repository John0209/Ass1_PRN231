using AutoMapper;
using BusinessObject.Service.IService;
using DataAccess.Models;
using DataAccess.RequestModel;
using DataAccess.ResponeModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace eStoreAPI.Controllers
{
	[Route("api/member")]
	[ApiController]
    
    public class MemberAPI : ControllerBase
	{
		IMemberService _member;
		IMapper _map;

		public MemberAPI(IMemberService member, IMapper map)
		{
			_member = member;
			_map = map;
		}

        [EnableQuery]
        [HttpGet("OData")]
        public async Task<IActionResult> GetMemberOData(ODataQueryOptions<Member> options)
        {
            return Ok(await _member.GetMemberOData(options,_map));
        }


        [HttpGet("Get-All")]
        public IActionResult GetMember()
        {
            var members = _member.GetMembers();
            if (members.Any())
            {
                var memberMap = _map.Map<IEnumerable<MemberRespone>>(members);
                return Ok(memberMap);
            }
            return BadRequest("Member is Empty!");
        }
        [HttpPost("Login")]
		public IActionResult Login(string email, string password)
		{
			var login= _member.CheckLogin(email, password);
			if(login != null)
			{
				return Ok(login);
			}
			return BadRequest();
		}

        
        [HttpGet("Get-By-Id")]
        public IActionResult GetMemberById(int id)
        {
            var members = _member.GetMemberById(id);
            if (members != null)
            {
                var memberMap = _map.Map<MemberRespone>(members);
                return Ok(memberMap);
            }
            return BadRequest("Member is Empty!");
        }
        [HttpGet("Search")]
        public IActionResult SearchMember(string serachs)
        {
            var members = _member.SearchMember(serachs);
            if (members.Any())
            {
                var memberMap = _map.Map<IEnumerable<MemberRespone>>(members);
                return Ok(memberMap);
            }
            return BadRequest("Member is Empty!");
        }
        [HttpPut("Update")]
        public IActionResult UpdateMember(MemberRequest member)
        {
            var members = _map.Map<Member>(member);
            var m_update = _member.UpdateMember(members);
            if (m_update)
                return Ok();
            else
                return BadRequest();
        }
        [HttpDelete("Delete")]
        public IActionResult DeleteMember(int id)
        {
            var members = _member.GetMemberById(id);
            if (members != null)
            {
                _member.DeleteMember(members);
                return Ok();
            }
            else
                return BadRequest();
        }
        [HttpPost("Create")]
        public IActionResult CreateMember(MemberRequest member)
        {
            var check = _member.GetMemberById(member.MemberId);
            if (check == null)
            {
                var membsers = _map.Map<Member>(member);
                _member.AddMember(membsers);
                return Ok();
            }
            else
                return BadRequest();
        }
    }
}
