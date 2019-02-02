using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CUResorts.Models
{
    public class GuestActions
    {

        public static List<Person> GetGuests()
        {
            CUResortEntities DB = new CUResortEntities();
            return DB.People.OrderBy(x => x.LNAME).ToList();
        }

        public static int GuestCount()
        {
            return GetGuests().Count;
        }

        public static Person GetPersonByID(int ID)
        {
            CUResortEntities DB = new CUResortEntities();
            return DB.People.Find(ID);
        }

        public static void AddGuest(Person p)
        {
            CUResortEntities DB = new CUResortEntities();
            DB.People.Add(p);
            DB.SaveChanges();
        }

        public static void UpdateGuest(Person p)
        {
            CUResortEntities DB = new CUResortEntities();
            DB.Entry(p).State = System.Data.Entity.EntityState.Modified;
            DB.SaveChanges();
        }

        public static void DeleteGuest(int ID)
        {
            CUResortEntities DB = new CUResortEntities();
            Person p = DB.People.Find(ID);
            DB.People.Remove(p);
            DB.SaveChanges();
        }
    }
    
    public class ReservationActions
    {
        public static List<Reservation> GetReservations()
        {
            // ordered by Date Reserved

            CUResortEntities DB = new CUResortEntities();
            return DB.Reservations.OrderBy(x => x.DateReserved).ToList();
        }

        public static Reservation GetReservationByID(int ID)
        {
            CUResortEntities DB = new CUResortEntities();
            return DB.Reservations.Find(ID);
        }

        public static int CountGuestReservations(int GuestID)
        {
            CUResortEntities DB = new CUResortEntities();
            return DB.Reservations.Where(x => x.GID == GuestID).Count();
        }

        public static int CountAllReservations()
        {
            return GetReservations().Count;
        }

        public static void AddReservation(Reservation r)
        {
            CUResortEntities DB = new CUResortEntities();
            if(r.DateReserved == null)
            {
                r.DateReserved = DateTime.Now;
            }
            DB.Reservations.Add(r);
            DB.SaveChanges();
        }

        public static void UpdateReservation(Reservation r)
        {
            CUResortEntities DB = new CUResortEntities();
            DB.Entry(r).State = System.Data.Entity.EntityState.Modified;
            DB.SaveChanges();
        }

        public static void DeleteReservation(int ID)
        {
            CUResortEntities DB = new CUResortEntities();
            Reservation r = DB.Reservations.Find(ID);
            DB.Reservations.Remove(r);
            DB.SaveChanges();
        }

        public static void CheckIn(Reservation r)
        {
            // TODO: validate if check in and out are null

            r.CheckIN = DateTime.Now;
            UpdateReservation(r);
        }

        public static void CheckOut(Reservation r)
        {
            // TODO: validate if check out is null and check in is a past datetime

            r.CheckOUT = DateTime.Now;
            UpdateReservation(r);
        }
    }

    public class AnemityActions
    {
        public static List<Anemity> GetAnemities()
        {
            CUResortEntities DB = new CUResortEntities();
            return DB.Anemities.OrderBy(x => x.Description).ToList();
        }
    }
    public class RoomActions
    {
        public static List<Room> GetRooms()
        {
            CUResortEntities DB = new CUResortEntities();
            return DB.Rooms.ToList();
        }
    }
        
        /*
         * <?php
//Reservations

     

function get_rooms() {
    global $db;
    $query = "SELECT * FROM room, roomtype WHERE room.roomTypeID = roomtype.roomTypeID ORDER BY room";
    $result = $db->query($query);
    $error = "";

    if ($result == false) {
        $error = $db->error;
    }

    if ($error != null) {
        include('../errors/error.php');
        exit();
    } else {
        return $result;
    }
}

//invoices
function get_invoices_by_date() {
    global $db;
    $query = "SELECT VID, invoice.GID, LNAME, FNAME, DatePaid, AmountPaid, PaymentType, Void "
            . "FROM invoice, person "
            . "WHERE invoice.GID = person.GID "
            . "ORDER BY DatePaid DESC";
    $result = $db->query($query);

    $error = "";

    if ($result == false) {
        $error = $db->error;
    }

    if ($error != null) {
        include('../errors/error.php');
        exit();
    } else {
        return $result;
    }
}

function get_invoice($VID) {
    global $db;
    $query = "SELECT * FROM invoice
              WHERE VID = '$VID'";

    $result = $db->query($query);
    $result = mysqli_fetch_array($result);
//$result = $result->fetch_row();
    return $result;
}

function add_invoice($VID, $GID, $AmountPaid, $PaymentType, $Void) {
    global $db;
    $DatePaid = date("Y-m-d H:i:s");
    $query = "INSERT INTO invoice VALUES ('$VID', '$GID', '$DatePaid', '$AmountPaid', '$PaymentType', '$Void')";
    //echo $query; die;
    mysqli_query($db, $query);
}

function delete_invoice($VID) {
    global $db;
    $query = "DELETE FROM invoice WHERE VID = '$VID'";

    mysqli_query($db, $query);
    //$db->exec($query);
}

function update_invoice($VID, $GID, $AmountPaid, $PaymentType, $Void) {
    global $db;
    $query = "UPDATE invoice
              SET GID = '$GID', "
            . "AmountPaid = '$AmountPaid', "
            . "PaymentType = '$PaymentType', "
            . "Void = '$Void' "
            . "WHERE VID = '$VID'";
    //echo $query; die;
    try {
        mysqli_query($db, $query);
    } catch (PDOException $e) {
        $error = $e->getMessage();
        include('../errors/error.php');
    }
}

function get_RID_reservation($RID) {
    global $db;
    $query = "SELECT RID, person.GID, LNAME, FNAME, room, DateReserved, reservStart, reservEnd, CheckIN, CheckOUT "
            . "FROM reservation, person "
            . "WHERE reservation.GID = person.GID "
            . "AND reservation.RID = $RID";
    $result = $db->query($query);

    $error = "";

    if ($result == false) {
        $error = $db->error;
    }

    if ($error != null) {
        include('../errors/error.php');
        exit();
    } else {
        return $result;
    }
}

function get_RID_charges($RID) {
    global $db;
    $query = "SELECT charges.RID, DateCharged, Description, StandardCost, Void "
            . "FROM charges, reservation, anemity "
            . "WHERE charges.RID = reservation.RID "
            . "AND charges.AID = anemity.AID "
            . "AND reservation.RID = $RID "
            . "AND Void = '' "
            . "ORDER BY DateCharged";
    $result = $db->query($query);

    $error = "";

    if ($result == false) {
        $error = $db->error;
    }

    if ($error != null) {
        include('../errors/error.php');
        exit();
    } else {
        return $result;
    }
}
function get_room_price($RID){
    global $db;
    $query = "SELECT StandardCost "
            . "FROM roomtype, reservation, room "
            . "WHERE room.room = reservation.room "
            . "AND room.roomTypeID = roomtype.roomTypeID "
            . "AND reservation.RID = $RID";
    $result = $db->query($query);
    $result = mysqli_fetch_array($result);
    return $result;
}
function get_total($RID){
    global $db;
    $query = "SELECT sum(StandardCost) AS 'Subtotal' "
            . "FROM charges, reservation, anemity "
            . "WHERE charges.RID = reservation.RID "
            . "AND charges.AID = anemity.AID "
            . "AND reservation.RID = $RID "
            . "AND Void = ''";
    $result = $db->query($query);
    $result = mysqli_fetch_array($result);
    return $result;
}

//charges

function get_charges_by_date() {
    global $db;
    $query = "SELECT CID, charges.RID, LNAME, FNAME, Description, DateCharged, Void "
            . "FROM charges, person, anemity, reservation "
            . "WHERE reservation.GID = person.GID "
            . "AND reservation.RID = charges.RID "
            . "AND charges.AID = anemity.AID "
            . "ORDER BY LNAME, FNAME";
    $result = $db->query($query);

    $error = "";

    if ($result == false) {
        $error = $db->error;
    }

    if ($error != null) {
        include('../errors/error.php');
        exit();
    } else {
        return $result;
    }
}

function get_charge($CID) {
    global $db;
    $query = "SELECT * FROM charges
              WHERE CID = '$CID'";

    $result = $db->query($query);
    $result = mysqli_fetch_array($result);
    return $result;
}

function add_charge($CID, $RID, $AID, $Void) {
    global $db;
    $DateCharged = date("Y-m-d H:i:s");
    $query = "INSERT INTO charges VALUES ('$CID', '$RID', '$AID', '$DateCharged', '$Void')";
    //echo $query; die;
    mysqli_query($db, $query);
}

function delete_charge($CID) {
    global $db;
    $query = "DELETE FROM charges WHERE CID = '$CID'";

    mysqli_query($db, $query);
    //$db->exec($query);
}

function update_charge($CID, $RID, $AID, $Void) {
    global $db;
    $query = "UPDATE charges
              SET RID = '$RID', "
            . "AID = '$AID', "
            . "Void = '$Void' "
            . "WHERE CID = '$CID'";
    //echo $query; die;
    try {
        mysqli_query($db, $query);
    } catch (PDOException $e) {
        $error = $e->getMessage();
        include('../errors/error.php');
    }
}
function get_people_by_reservation(){
    global $db;
    $query = "SELECT RID, reservStart, LNAME, FNAME "
            . "FROM reservation, person "
            . "WHERE reservation.GID = person.GID "
            . "ORDER BY LNAME, reservStart DESC";
    $result = $db->query($query);
    $error = "";

    if ($result == false) {
        $error = $db->error;
    }

    if ($error != null) {
        include('../errors/error.php');
        exit();
    } else {
        return $result;
    }
}

//Employees
function get_employee_count() {
    global $db;
    $query = 'SELECT count(*) FROM employee';
    $result = $db->query($query)->fetch_assoc()['count(*)'];
    return $result;
}

function get_employees() {
    global $db;
    $query = "SELECT EmpID, person.GID, LNAME, FNAME, employee.EmpRoleID, Permissions, Password "
            . "FROM employee, person, employee_roles "
            . "WHERE person.GID = employee.GID "
            . "AND employee.EmpRoleID = employee_roles.EmpRoleID "
            . "ORDER BY LNAME";
    $result = $db->query($query);
    $error = "";

    if ($result == false) {
        $error = $db->error;
    }

    if ($error != null) {
        include('../errors/error.php');
        exit();
    } else {
        return $result;
    }
}

function get_employee($EmpID) {
    global $db;
    $query = "SELECT * FROM employee WHERE EmpID = '$EmpID'";
    $result = $db->query($query);
    $result = mysqli_fetch_array($result);
    return $result;
}

function get_employee_role($EmpRoleID) {
    global $db;
    $query = "SELECT * FROM employee_roles WHERE EmpRoleID = '$EmpRoleID'";
    $result = $db->query($query);
    $result = mysqli_fetch_array($result);
    return $result;
}

function get_roles() {
    global $db;
    $query = "SELECT * FROM employee_roles ORDER BY EmpRoleID";
    $result = $db->query($query);
    $error = "";

    if ($result == false) {
        $error = $db->error;
    }

    if ($error != null) {
        include('../errors/error.php');
        exit();
    } else {
        return $result;
    }
}

function get_people() {
    global $db;
    $query = "SELECT * FROM person ORDER BY LNAME";
    $result = $db->query($query);
    $error = "";

    if ($result == false) {
        $error = $db->error;
    }

    if ($error != null) {
        include('../errors/error.php');
        exit();
    } else {
        return $result;
    }
}

function add_employee($EmpID, $GID, $EmpRoleID, $PASS) {
    global $db;
    $encryptedPass = encrypt($PASS);
    $query = "INSERT INTO employee values ('$EmpID','$GID', '$EmpRoleID', '$encryptedPass')";
    mysqli_query($db, $query);
}

function update_employee($EmpID, $GID, $EmpRoleID, $PASS) {
    global $db;
    $encryptedPass = encrypt($PASS);
    $query = "UPDATE employee
              SET GID = '$GID', EmpRoleID = '$EmpRoleID', Password = '$encryptedPass'
              WHERE EmpID = '$EmpID'";

    try {
        mysqli_query($db, $query);
    } catch (PDOException $e) {
        $error = $e->getMessage();
        include('../errors/error.php');
    }
}

function delete_employee($EmpID) {
    global $db;
    $query = "DELETE FROM employee WHERE EmpID = '$EmpID'";
    mysqli_query($db, $query);
}

function encrypt($password) {
    if (defined("CRYPT_BLOWFISH") && CRYPT_BLOWFISH) {
        $salt = '$2y$13$' . substr(md5(uniqid(rand(), true)), 0, 22);
        return crypt($password, $salt);
    }
}

function verify($password, $hashedPassword) {
    return crypt($password, $hashedPassword) == $hashedPassword;
}


//HouseKeeping
function clean($room) {
    global $db;
    $query = "UPDATE room "
            . "SET RoomStatus = '0' "
            . "WHERE room = $room";
    try {
        mysqli_query($db, $query);
    } catch (PDOException $e) {
        $error = $e->getMessage();
        include('../errors/error.php');
    }
}

function dirty($ruum) {
    global $db;
    $query = "UPDATE room "
            . "SET RoomStatus = '1' "
            . "WHERE room = $ruum";
    //echo $query; die;
    try {
        mysqli_query($db, $query);
    } catch (PDOException $e) {
        $error = $e->getMessage();
        include('../errors/error.php');
    }
}

function dirty_alg() {
    global $db;
    $query = "SELECT last_refresh FROM dirty_alg";
    $result = $db->query($query);
    $result = mysqli_fetch_array($result);
    return $result;
}

function dirty_alg_update($refresh) {
    global $db;
    $query = "UPDATE dirty_alg "
            . "SET last_refresh = '$refresh' "
            . "WHERE id = '0'";
    //echo $query; die;
    try {
        mysqli_query($db, $query);
    } catch (PDOException $e) {
        $error = $e->getMessage();
        include('../errors/error.php');
    }
}

function get_dirty_rooms() {
    global $db;
    $query = "SELECT room, Style, Smoking FROM room, roomtype WHERE room.roomTypeID = roomtype.roomTypeID AND RoomStatus = '1' ORDER BY room";
    $result = $db->query($query);
    $error = "";

    if ($result == false) {
        $error = $db->error;
    }

    if ($error != null) {
        include('../errors/error.php');
        exit();
    } else {
        return $result;
    }
}

function get_reserved_rooms() {
    global $db;
    $query = "SELECT * "
            . "FROM reservation ";
    $result = $db->query($query);
    $error = "";
    //echo $query; die;
    if ($result == false) {
        $error = $db->error;
    }

    if ($error != null) {
        include('../errors/error.php');
        exit();
    } else {
        return $result;
    }
}

//Reports

function get_spent_report(){
    global $db;
    $month = date("m");
    $query = "SELECT LNAME, FNAME, sum(AmountPaid) AS 'Total Spent' 
FROM invoice, person 
WHERE invoice.GID = person.GID 
AND MONTH(DatePaid) = $month 
AND Void = '' 
GROUP BY invoice.GID 
ORDER BY `Total Spent` DESC";
    $result = $db->query($query);
    $error = "";

    if ($result == false) {
        $error = $db->error;
    }

    if ($error != null) {
        include('../errors/error.php');
        exit();
    } else {
        return $result;
    }
}
         */
    
}