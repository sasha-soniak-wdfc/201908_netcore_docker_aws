<img src="../../img/logo.png" alt="Chmurowisko logo" width="200" align="right">
<br><br>
<br><br>
<br><br>

# Creating ECR repository

## LAB Overview

#### In this lab you will create ECR repository for storing docker images.

## Task 1: Creating repository
In this task you will create ECR repository

1. In the AWS Management Console, on the **Services** menu, click **ECR**.
2. Click **Create Repository**.
3. Enter a name for your rpository, i.e. *student-X-repo*.
4. Set **Image tag mutability** to mutable.
5. Click **Create Repository**.

## Task 2: Setting permissions

In this task you will add permissions for your repository.

6. Find your repository and click on its name.
7. On the left pane, select **Permissions**.
8. Click **Edit**.
9. Click **Add statement**.
10. Enter a name for the statement.
11. As **Effect** select **Allow**.

Here, you can select principals, AWS accunts, user or roles that can use the repository.

12. Mark the checkmark for **Everyone**.
13. Scroll down and add following actions to the policy:
* ecr:BatchGetImage,
* ecr:DescribeImages
* ecr:PutImage.
14. Click **Save**.
15. Click **Edit policy JSON** and look into the policy.
16. Click **Close**.

## Task 3: Setting Lifecycle Policy

In this task you will set lifecycle policy that will automatically delete old and untagged images.

17. On the left pane, select **Lifecycle Policy**.
18. Click **Create rule**.
19. Set **Rule priority** to *1*.
20. Enter a rule description.
21. For **Image status** set **Untagged**.
22. For **Match criteria** select **Since image pushed** and set the value to *1* day.
23. Click **Save**.
24. Click **Create rule**.
25. Set **Rule priority** to *2*.
26. Enter a rule description.
27. For **Image status** set **Any**.
28. For **Match criteria** select **Since image pushed** and set the value to *3* days.
29. Click **Save**.

## Task 4: Testing Lifecycle Policies

In this task you will test lifecycle policies you created in task 3.

30. Select first of your lifecycle policies and click **Actions**.
31. Select **Copy Policies to test rules**.
32. Select second of your lifecycle policies and click **Actions**.
33. Select **Copy Policies to test rules**.
34. Click **Save and run tests**.

You will get an empty list (you have no images inside your repository), but if you had any images that match rules, you would be listed in **Image matches for test lifecycle rules** area.

## Task 5: Creating repositories for the app

In this task you will prepare 3 repositories for the application.

35. Repeat steps 1-5 (Task 1) and create 3 repositories:
* student-X-webClient,
* student-X-service1,
* student-X-service2.

## END LAB

<br><br>

<center><p>&copy; 2019 Chmurowisko Sp. z o.o.<p></center>