package main

import (
	"log"
	"net/http"
	sw "github.com/AlexeyRyabichev/EnglishTester/tree/master/server/go"
	// sw "./go"
)

func main() {
	log.Printf("Server started")

	log.Fatal(http.ListenAndServe(":8000", http.FileServer(http.Dir("../web"))))

}