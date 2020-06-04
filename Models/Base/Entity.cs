namespace Models.Base
{
	public abstract class Entity : object
	{
		public Entity() : base()
		{
			Id =
				System.Guid.NewGuid();
					
		}

		// **********
		/// <summary>
		/// شماره منحصر به فرد
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.Id))]

		[System.ComponentModel.DataAnnotations.Required
			(AllowEmptyStrings = false,
			ErrorMessageResourceType = typeof(Resources.Messages),
			ErrorMessageResourceName = nameof(Resources.Messages.RequiredValidationErrorMessage))]
		public System.Guid Id { get; set; }
		// **********

		
	}
}
