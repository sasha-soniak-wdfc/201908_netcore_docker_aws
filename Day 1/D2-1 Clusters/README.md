  <img src="../../img/logo.png" alt="Chmurowisko logo" width="200" align="right">
  <br><br>
  <br><br>
  <br><br>


# ECS  Creating clusters

## LAB Overview

#### This lab will demonstrate:
* Creating cluster using AWS console
* Creating cluster using ECS CLI
* Deleting cluster



## Task 1: Create an ECS Cluster

In this task you will create ECS Cluster.

1. In the AWS Management Console, on the **Services** menu, click **ECS**.
2. Click **Create Cluster**.
3. Choose "EC2 Linux + Networking" option.
4. Click **Next step**.
5. Enter a name for your cluster, e.g. "Student-X-Cluster".
6. Choose "On-demand instance".
7. Choose "t3.micro" as your instance type.
8. Set number of instances to 2.
9. Leave the rest unchanged and click **Create**.

Wait until the cluster is ready.

10. Click **View cluster"
11. Click **ECS Instances** and check, if there is an instance active.
12. Look into Cloud Formation stacks. Find your ECS cluster and examine the template and created resources.

## Task 2: Deleting the cluster

In this task you will delete ECS Cluster

13. Go back to your ECS console.
14. Find your cluster and click on its name.
15. Click **Delete Cluster**.
16. Enter the phrase "delete me".
17. Click **Deelte**.

## Task 3. Installing ECS CLI.

In this task you will install ECS CLI.

18. Open your Cloud9 environment.
19. Download *ECS-CLI* by typing ``sudo curl -o /usr/local/bin/ecs-cli https://amazon-ecs-cli.s3.amazonaws.com/ecs-cli-linux-amd64-latest``.
20. Apply execute permissions to the binary by typing ``sudo chmod +x /usr/local/bin/ecs-cli``.
21. Verify that the CLI is working properly byb typing ``ecs-cli --version``.

## Task 4. Creating ECS cluster using CLI.

In this tak you will create ECS cluster using ECS CLI.

22. Check if you have any key-pair that allows you to log in into EC2 instances. If not, please create one. You may ask the leader for help.
23. In the terminal window of your Cloud9 environent type the following command. Please replace X within cluster name and enter your key pair name
``
ecs-cli up --keypair YOUR-KEYPAIR-NAME \
--instance-type t2.micro \
--size 2 \
--cluster STUDENT-X-CLI-CLUSTER \
--capability-iam \
--verbose
``
If you want, you can open CloudFormation console and look into creation process.

24. When the process finishes, open ECS console and check if there are any new ECS clusters with EC2 instances inside.

## Task 5. Manually configuring and adding EC2 instance to the cluster.

In this task you will create EC2 instance, install Docker and ECS Container Agent and add it to the existing ECS Cluster.

25. In the AWS Management Console, on the **Services** menu, click **EC2**.
26. Click **Launch Instance**.
27. Select standard AMI **Amazon Linux AMI 2018.03.0 (HVM), SSD Volume Type**.
28. Select **t2.micro** and click **Next: Configure Instance Details**.
29. As **Network** select the VPC your cluster is running in.
30. Select any public subnet as **Subnet**.
31. As **Auto-assign Public IP** select **Enable**.
32. Select **ecsInstanceRole** as **IAM role**.
33. Unwind **Advanced Details** tab.
34. Download [UserData file](ec2_userdata.txt).
35. Edit the file by replacing the cluster name with your cluster name.
36. Paste the contents of the file as **User data**.
37. Click **Next: Add Storage**.
38. Click **Next: Add Tags**.
39. Click **Next: Configure Security Group**.
40. Leave the settings unchanged and click **Review and Launch**.
41. Click **Launch**.
42. Select your key pair and click **Launch Instances**.

Wait until your instance is running.

43. Connect to your EC2 instance using *ssh*.
``
ssh -i "YOUR-KEY-NAME.pem" ec2-user@ADDRESS OF YOUR INSTANCE
``
44. Update the instance by typing ``sudo yum update -y``.
45. Install docker:
```
sudo yum install docker -y
sudo service docker start
sudo usermod -a -G docker $USER
```
46. Log out by typing ``exit``.
47. Connect to your instance using ssh.
48. Type ``docker info`` to check if everything works fine.
49. Install ECS Agent by typing:
```
sudo yum install ecs-init -y
sudo start ecs
```
50. Look into ECS logs:
```
tail -f /var/log/ecs/ecs*
```
51. Type ``docker ps`` and look into output. There should be *agent* constainer running.
52. Open ECS console, find your cluster anc click on its name.
53. Select **ECS Instances** tab. How many EC2 instances now have you got in the cluster?

## Task 6. Examining ECS Agent endpoints.

In this task you will look into ECS Agent metadata,

54. Install *jq* utility by typing:
```
sudo yum install jq -y
```

ECS Agent listens on port 51678.

55. Examine agent metadata by typing:
```
curl http://localhost:51678/v1/metadata | jq
```

You should get some metadata similiar to:
```json
{
  "Cluster": "STUDENT-21-CLI-CLUSTER",
  "ContainerInstanceArn": "arn:aws:ecs:eu-west-1:655379451354:container-instance/9cc95e9f-a521-4e8c-aba8-9bb0998c4bf3",
  "Version": "Amazon ECS Agent - v1.29.1 (f95f731b)"
}
```
56. To get a list of tasks you can use another endpoint:
```
curl http://localhost:51678/v1/tasks | jq
```

## END LAB

This is the end of this laboratory. 

Follow these steps to close the console, end your lab, and delete the resources.

57. In the AWS Management Console, on the **Services** menu, click **ECS**.
58. Click **Clusters**.
59. Find your cluster and click on its name.
60. Click **Delete Cluster**.
62. Click **Delete**.
62. In the AWS Management Console, on the **Services** menu, click **EC2**.
63. Find the instance you created in task 5.
64. Select it and click **Action**.
65. Select **Instance State**.
66. Click **Terminate** and **Yes, Terminate**.

If any of your cluster's instances are still working, please repeat steps 64-66 for each of them.

<br><br>

<center><p>&copy; 2019 Chmurowisko Sp. z o.o.<p></center>