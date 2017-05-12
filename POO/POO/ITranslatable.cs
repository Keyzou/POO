namespace POO
{
    internal interface ITranslatable
    {
        /// <summary>
        /// Translate la forme
        /// </summary>
        /// <param name="dx">Valeur du déplacement en x</param>
        /// <param name="dy">Valeur du déplacement en y</param>
        void Translation(int dx, int dy);
    }
}