namespace DataBaseWork
{
    public class DataField
    {
        public string Field;
        public string Value;
        public DataField()
        {
            Field = "";
            Value = "";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataField"/> class.
        /// </summary>
        /// <param name="Field">Fieldname.</param>
        /// <param name="Value">Value of the field.</param>
        public DataField(string Field, string Value)
        {
            this.Field = Field;
            this.Value = Value;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DataField"/> class.
        /// </summary>
        /// <param name="Field">Fieldname.</param>
        /// <param name="Value">Value of the field.</param>
        public DataField(string Field, int Value)
        {
            this.Field = Field;
            this.Value = Value.ToString();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DataField"/> class.
        /// </summary>
        /// <param name="Field">Fieldname.</param>
        /// <param name="Value">Value of the field.</param>
        public DataField(string Field, float Value)
        {
            this.Field = Field;
            this.Value = Value.ToString();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DataField"/> class.
        /// </summary>
        /// <param name="Field">Fieldname.</param>
        /// <param name="Value">Value of the field.</param>
        public DataField(string Field, double Value)
        {
            this.Field = Field;
            this.Value = Value.ToString();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DataField"/> class.
        /// </summary>
        /// <param name="Field">Fieldname.</param>
        /// <param name="Value">Value of the field.</param>
        public DataField(string Field, bool Value)
        {
            this.Field = Field;
            this.Value = Value.ToString();
        }
    }
}