using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Util;
using System;
using System.Threading.Tasks;

namespace s3
{
  class Program
  {
    private static string ACCESS_KEY = "AKIAZRF5IZXNO4LDURE4";
    private static string SECRET_KEY_ID = "sslCThVyxsVKs5N/q+F2lmXlcPVIXPr1FA60x0GG"; 
    
    private static RegionEndpoint bucketRegion;
    private static IAmazonS3 s3Client;

    static void Main(string[] args)
    {
      if (args.Length < 2) {
        Console.Write("Usage: <the bucket name> <the AWS Region to use>\n" +
          "Example: my-test-bucket eu-west-1\n");
        return;
      }

      if (args[1] == "eu-west-1") {
        bucketRegion = RegionEndpoint.EUWest1;
      } else {
        Console.WriteLine("Cannot continue. The only supported AWS Region ID is " +
          "'eu-west-1'.");
        return;
      }

      s3Client = new AmazonS3Client(ACCESS_KEY, SECRET_KEY_ID, bucketRegion);
      var bucketName = args[0];

      // Create the bucket.
      try
      {
        if (DoesBucketExist(bucketName))
        {
          Console.WriteLine("Cannot continue. Cannot create bucket. \n" +
            "A bucket named '{0}' already exists.", bucketName);
          return;
        } else {
          Console.WriteLine("\nCreating the bucket named '{0}'...", bucketName);
          s3Client.PutBucketAsync(bucketName).Wait();
        }
      }
      catch (AmazonS3Exception e)
      {
        Console.WriteLine("Cannot continue. {0}", e.Message);
      }
      catch (Exception e)
      {
        Console.WriteLine("Cannot continue. {0}", e.Message);
      }

      // Confirm that the bucket was created.
      if (DoesBucketExist(bucketName))
      {
        Console.WriteLine("Created the bucket named '{0}'.", bucketName);
      } else {
        Console.WriteLine("Did not create the bucket named '{0}'.", bucketName);
      }

      // Delete the bucket.
      Console.WriteLine("\nDeleting the bucket named '{0}'...", bucketName);
      s3Client.DeleteBucketAsync(bucketName).Wait();

      // Confirm that the bucket was deleted.
      if (DoesBucketExist(bucketName))
      {
        Console.WriteLine("Did not delete the bucket named '{0}'.", bucketName);
      } else {
        Console.WriteLine("Deleted the bucket named '{0}'.", bucketName);
      };

      // List current buckets.
      Console.WriteLine("\nMy buckets now are:");
      var response = s3Client.ListBucketsAsync().Result;

      foreach (var bucket in response.Buckets)
      {
        Console.WriteLine(bucket.BucketName);
      }
    }

    static bool DoesBucketExist(string bucketName)
    {
      if ((AmazonS3Util.DoesS3BucketExistAsync(s3Client, bucketName).Result))
      {
        return true;
      } else {
        return false;
      }
    }
  }
}
