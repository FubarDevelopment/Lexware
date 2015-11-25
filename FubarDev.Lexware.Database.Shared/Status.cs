namespace FubarDev.Lexware.Database.Shared
{
    /// <summary>
    /// Status-Kennzeichen für Abo-Vorlagen und Aufträge
    /// </summary>
    public class Status
    {
        /// <summary>
        /// Holt oder setzt einen Wert, der angibt, ob der Auftrag gebucht wurde
        /// </summary>
        public virtual bool Gebucht { get; set; }

        /// <summary>
        /// Holt oder setzt einen Wert, der angibt, ob der Auftrag übernommen wurde
        /// </summary>
        public virtual bool Uebernommen { get; set; }

        /// <summary>
        /// Holt oder setzt einen Wert, der angibt, ob der Auftrag gedruckt wurde
        /// </summary>
        public virtual bool Gedruckt { get; set; }

        /// <summary>
        /// Holt oder setzt einen Wert, der angibt, ob der Auftrag exportiert wurde
        /// </summary>
        public virtual bool Exportiert { get; set; }

        /// <summary>
        /// Holt oder setzt einen Wert, der angibt, ob der Auftrag geliefert wurde
        /// </summary>
        public virtual bool Geliefert { get; set; }

        /// <summary>
        /// Holt oder setzt einen Wert, der angibt, ob der Auftrag gemahnt wurde
        /// </summary>
        public virtual bool Gemahnt { get; set; }

        /// <summary>
        /// Holt oder setzt einen Wert, der angibt, ob der Auftrag bezahlt wurde
        /// </summary>
        public virtual bool Bezahlt { get; set; }

        /// <summary>
        /// Holt oder setzt einen Wert, der angibt, ob der Auftrag einen Abschlag hat
        /// </summary>
        public virtual bool Abschlag { get; set; }

        /// <summary>
        /// Holt oder setzt einen Wert, der angibt, ob der Auftrag weitergeführt wurde
        /// </summary>
        public virtual bool Weitergefuehrt { get; set; }

        /// <summary>
        /// Holt oder setzt einen Wert, der angibt, ob der Auftrag komplett erfasst wurde
        /// </summary>
        public virtual bool ErfassungKomplett { get; set; }

        /// <summary>
        /// Holt oder setzt einen Wert, der angibt, ob der Auftrag gemailt wurde
        /// </summary>
        public virtual bool Gemailt { get; set; }

        /// <summary>
        /// Holt oder setzt einen Wert, der angibt, ob der Auftrag frankiert wurde
        /// </summary>
        public virtual bool Frankiert { get; set; }

        /// <summary>
        /// Holt oder setzt einen Wert, der angibt, ob der Auftrag storniert wurde
        /// </summary>
        public virtual bool Storniert { get; set; }
    }
}
