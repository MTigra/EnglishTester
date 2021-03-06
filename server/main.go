package main

import (
	"./go/DbWorker"
	"./go/swagger"
	"log"
	"net/http"
)

func main() {
	log.Printf("Server started")
	DbWorker.InitDB()
	DbWorker.CreateSchemaTeachers()
	DbWorker.CreateSchemaStudents()
	DbWorker.CreateSchemaTest()
	DbWorker.CreateSchemaAudio()
	DbWorker.CreateSchemaScore()
	DbWorker.MockAnswers()
	DbWorker.CreateSchemaAuditory()
	DbWorker.AddToQueuePost()
	router := swagger.NewRouter()
	//sw.InsertTests()
	//DocParser.GetTextFromDocx()
	log.Fatal(http.ListenAndServe(":8080", router))
}
