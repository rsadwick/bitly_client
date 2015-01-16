namespace bitly_rest_client {
    public class BitlyUrl {
        public string status_code { get; set; }
        public data data { get; set; }
    }

    public class data {
        public string long_url { get; set; }
        public string url { get; set; }
    }
}