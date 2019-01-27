<?php

namespace App;

$user1 = DB::table("users")
    ->where("active", 1)
    ->OrderBy("name", "DESC")
    ->get();

$user2 = DB::table("users")
    ->find(1)
    ->get();

echo $user1->name;
echo $user2->name;