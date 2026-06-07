using System;

namespace OrbitOps.Net.Domain.ValueObjects
{
    public struct CoordenadasOrbitais
    {
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
        public double AltitudeKm { get; private set; }

        public CoordenadasOrbitais(double latitude, double longitude, double altitudeKm)
        {
            Latitude = latitude;
            Longitude = longitude;
            AltitudeKm = altitudeKm;
        }

        public string ObterLocalizacaoFormatada() =>
            $"Lat: {Latitude:F4}, Lon: {Longitude:F4}, Alt: {AltitudeKm:F2}km";
    }
}