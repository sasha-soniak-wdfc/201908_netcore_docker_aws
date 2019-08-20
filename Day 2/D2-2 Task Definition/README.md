<img src="../../img/logo.png" alt="Chmurowisko logo" width="200" align="right">
<br><br>
<br><br>
<br><br>

# Creating Task Definition and ECS Task

## LAB Overview

#### During this lab you will prepare a task definition. Then you will schedule several tasks using ECS Cluster.

## Task 1: Preparing a Task definition

1. On the **Services** menu, click **ECS**.
2. Click **Task definitions**.
3. Click **Create new Task Definition**.
4. Select **EC2** and click **Next step**.
5. Enter a **Task Definition Name**, *student-X-task-definition*.
6. Click **Add container**.
7. Enter a **Container name**, *student-X-container*.
8. Enter *przemekmalak/netcoreconsolelogs* your image URI.
9. Select **Hard Limit** for **Memory Limits** and set it to *128*.
11. Scroll down and click checkmark the **Auto-configure CloudWatch Logs** option.
12. Scroll down and click **Add**.
13. Leave the rest unchanged, click **Create** and **View task definition**.

## Task 2: Cretaing task.

14. Click **Clusters**.
15. Find your cluster and click on it's name.
16. Select **Tasks** and click **Run new task**.
17. Select **EC2** as **Launch type**.
18. Select your definition created in previous task as **Task definition**.
19. Enter *2* as **Number of tasks**.
20. Leave the rest unchanged and click **Run Task**.

Wait until **Last status** changes to **STOPPED**.

21. Look into Cloud Watch logs and check wheter the tasks were spread across all instances.

## Task 3: Changing task placement strategy.

22. Go back to the ECS Console.
23. Find your cluster and click on its name.
24. Select **Tasks** and click **Run new task**.
25. Select **EC2** as **Launch type**.
26. Select your definition created in previous task as **Task definition**.
27. Enter *2* as **Number of tasks**.
28. Select **BinPack** as **Placement Template**.
29. Click **Run Task**.

Wait until **Last status** changes to **STOPPED**.

30. Look into Cloud Watch logs and check wheter the tasks were spread across all instances or only one instance.

## Task 7: Creating scheduled task

In this task you will create scheduled task which will execute every 1 minute.

31. Once again, in the ECS console find your cluster and click on its name.
32. Select **Scheduled Tasks** and click **Create**.
33. Enter *student-X-rule* as **Schedule rule name**.
34. Select **Cron expression** as **Schedule rule type**.
35. Paste following expression
```
cron(* * * * ? *)
```
as **Cron expression**.
36. Enter *student-X-target* as **Target Id**.
37. Select **EC2** as **Launch type**.
38. Select your task definition and the latest version.
39. Leave the rest unchanged and click **Create**.
40. Click **View scheduled task**.

Wait 3 or so minutes and examine CloudWatch logs.

41. Click **View CloudWatch metrics**.
42. Examine metrisc for your rule. You cna also check whether or not there are any logs in your Log Group.

## Task 8: Cleaning up

43. In the ECS console, find your cluster and scheduled task.
44. Select the checkmark left to the rule name.
45. Click **Delete** twice.
46. Click **Done**.

## END LAB

<br><br>

<center><p>&copy; 2019 Chmurowisko Sp. z o.o.<p></center>