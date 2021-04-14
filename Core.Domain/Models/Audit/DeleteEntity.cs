using Core.InterFaces.IAudit;
using System;

namespace Core.Domain.Models.Audit
{
    public class DeleteEntity : IDeleteEntity
    {
        public bool IsDeleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string DeletedBy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime? DeletedDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
