﻿using MongoDB.Bson.Serialization.Attributes;

namespace Base
{
	/// <summary>
	/// Component的Id与Owner Entity Id一样
	/// </summary>
	public abstract class Component : Object
	{
		[BsonIgnore]
		public Entity Owner { protected get; set; }

		protected T GetOwner<T>() where T: Entity
		{
			return this.Owner as T;
		}

		protected Component()
		{
		}

		protected Component(long id): base(id)
		{
		}

		protected T GetComponent<T>() where T: Component
		{
			return this.Owner.GetComponent<T>();
		}

		public override void Dispose()
		{
			if (this.Id == 0)
			{
				return;
			}
			
			base.Dispose();
		}
	}
}