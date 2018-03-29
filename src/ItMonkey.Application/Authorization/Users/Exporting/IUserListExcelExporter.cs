using System.Collections.Generic;
using ItMonkey.Authorization.Users.Dto;
using ItMonkey.Dto;

namespace ItMonkey.Authorization.Users.Exporting
{
    public interface IUserListExcelExporter
    {
        FileDto ExportToFile(List<UserListDto> userListDtos);
    }
}