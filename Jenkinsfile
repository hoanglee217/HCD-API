pipeline {
    agent any
    environment {
        IMAGE_NAME = "hoangcodedao/api"
        IMAGE_TAG = "latest"
    }
    stages {
        stage('Docker Compose Setup') {
            steps {
                script {
                    echo "Deploying application."
                    sh "docker compose down"
                    sh "docker compose up -d"
                }
            }
        }
    }
}