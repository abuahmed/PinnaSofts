using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PinnaSofts.Entity.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PinnaSofts.Entity
{
    public abstract class EntityBase: IObjectState
    {
        [NotMapped]
        public ObjectState ObjectState { get; set; }
    }
}
