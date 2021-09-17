using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Core
{
	public abstract class GenericEntity
	{
        protected GenericEntity()
        {
            CreatedDate = Constants.EmptyDate;
            UpdatedDate = Constants.EmptyDate;
        }

		[Key, Column(Order = 0)]
		public int Id { get; set; }

		[DataType(DataType.Date)]
		public DateTime CreatedDate { get; set; }

		[DataType(DataType.Date)]
		public DateTime UpdatedDate { get; set; }

		public override bool Equals(object obj)
		{
			if (obj == null || GetType() != obj.GetType())
			{
				return false;
			}
			return Id == ((GenericEntity)obj).Id;
		}

		public override int GetHashCode()
		{
			return Id.GetHashCode();
		}
	}
}