using Model.Client.Data;
using Model.Client.Mapper;
using GS = Model.Global.Service;
using GD = Model.Global.Data;
using System.Collections.Generic;

namespace Model.Client.Service
{
    public static class DocumentService
    {
        public static int? Create(Document doc)
        {
            return GS.DocumentService.Create(Mappers.ToGlobal(doc));
        }

        public static Document Get(int Id)
        {
            return Mappers.ToClient(GS.DocumentService.Get(Id));
        }
    }
}
