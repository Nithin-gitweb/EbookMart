@{
    ViewBag.Title = "Index";
}


</script>

<h2>Admin Panel</h2>

<center><h3>Authentication Data</h3></center>


<div id="AuthenticationTable">
<table>
    <tr>
        <th style="padding: 30px 30px 30px 30px">User id</th>
        <th style="padding: 30px 30px 30px 30px">User Name</th>
        <th style="padding: 30px 30px 30px 30px">Email</th>
        <th style="padding: 30px 30px 30px 30px">Phone Number</th>
        <th style="padding: 30px 30px 30px 30px">Password</th>
        <th style="padding: 30px 70px 30px 30px">Action</th>
    </tr>
    @foreach (var item in ViewBag.authentication)
    {
        <tr>
            <td><center>@item.id</center></td>
            <td><center>@item.Username</center></td>
            <td>@item.Email</td>
            <td><center>@item.PhoneNumber</center></td>
            <td><center>@item.Password</center></td>
            <td>@Html.ActionLink("Delete User", "") | @Html.ActionLink("Edit User", "") </td>
        </tr>
    }
</table>
    </div>
       


