using System.Diagnostics;
using Location = Microsoft.Maui.Devices.Sensors.Location;

namespace MauiUI.Services
{
    public interface ILocationService
    {
        bool IsListening { get; }
        Location LatestLocation { get; }
        Task<bool> StartListeningForegroundAsync();
        void OnStopListening();

    }

    public class LocationService : ILocationService
    {
        private bool _isListening = false;
        private Location _latestLocation { get; set; } = new Location(0.0D, 0.0D);
        public bool IsListening => _isListening;

        public Location LatestLocation => _latestLocation;
        private TimeSpan minimumTimeDefault = TimeSpan.FromSeconds(1);

        public async Task<bool> StartListeningForegroundAsync()
        {
            try
            {
                var successStatus = false;
                if (!_isListening)
                {
                    Geolocation.LocationChanged += Geolocation_LocationChanged;
                    var request = new GeolocationListeningRequest(GeolocationAccuracy.Medium);
                    successStatus = await Geolocation.StartListeningForegroundAsync(request);
                    _isListening = true;
                }
                else
                {
                    successStatus = true;
                }
                var status = successStatus
                       ? "Started listening for foreground location updates"
                       : "Couldn't start listening";
                Debug.WriteLine(status);
                return successStatus && _isListening;
            }
            catch (Exception ex)
            {
                // Unable to start listening for location changes
                var title = "Unable to start listening for location changes";
                Debug.WriteLine(title + "| Error Message : " + ex.Message);
                return false;
            }
        }

        private void Geolocation_LocationChanged(object sender, GeolocationLocationChangedEventArgs e)
        {
            // Process e.Location to get the new location
            var location = e.Location;
            var latitude = location.Latitude;
            var longitude = location.Longitude;
            var dateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            Debug.WriteLine("Device Location Changed at {0} With Latitude : {1}, Longitude : {2}", dateTime, latitude, longitude);
            _latestLocation = location;
        }

        public void OnStopListening()
        {
            if (_isListening)
            {
                try
                {
                    Geolocation.LocationChanged -= Geolocation_LocationChanged;
                    Geolocation.StopListeningForeground();
                    var status = "Stopped listening for foreground location updates";
                    Debug.WriteLine(status);
                }
                catch (Exception ex)
                {
                    // Unable to stop listening for location changes
                    var title = "Unable to stop listening for location changes";
                    Debug.WriteLine(title + "| Error Message : " + ex.Message);
                }
                _isListening = false;
            }
            else
            {
                var status = "Started listening for foreground location has not been started yet";
                Debug.WriteLine(status);
            }
        }

       
    }
}
