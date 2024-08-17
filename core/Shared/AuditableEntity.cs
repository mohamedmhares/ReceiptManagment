﻿namespace Core.Shared;

    public abstract class AuditableEntity:BaseEntity
    {
        public DateTime Created { get; set; } = DateTime.Now;

        public string? CreatedBy { get; set; }

        public DateTime? LastModified { get; set; }

        public string? LastModifiedBy { get; set; }
    }