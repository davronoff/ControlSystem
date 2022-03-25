namespace DavomatProject.Api.Services
{
    public class AppConfiguration
    {
		public AppConfiguration()
		{
			BucketName = "rtm-images";
			Region = "us-east-1";
			AwsAccessKey = "AKIA2PK65C7G5XOEXK6D";
			AwsSecretAccessKey = "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";
			AwsSessionToken = "";
		}

		public string BucketName { get; set; }
		public string Region { get; set; }
		public string AwsAccessKey { get; set; }
		public string AwsSecretAccessKey { get; set; }
		public string AwsSessionToken { get; set; }
	}
}
