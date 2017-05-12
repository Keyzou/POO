namespace POO
{
    internal interface IRotatable
    {
        /// <summary>
        /// Applique une rotation a la forme.
        /// </summary>
        /// <param name="angle">Angle de rotation</param>
        /// <param name="cx">Coordonnée x du centre de rotation</param>
        /// <param name="cy">Coordonnée y du centre de rotation</param>
        void Rotation(int angle, int cx, int cy);
    }
}