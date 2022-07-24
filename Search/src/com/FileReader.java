package com;

import com.Doc;
import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.Scanner;

public class FileReader {
    private final static String FOLDER = "tests/";

    public static ArrayList<Doc> readFiles() {
        ArrayList<Doc> documents = new ArrayList<>();
        String [] fileNames = detectFileNames();

        for (int i = 0; i < fileNames.length; i++) {
                File file = new File(FOLDER + fileNames[i]);
                String context = getFileContext(file);

                documents.add(new Doc(fileNames[i], context));
        }

        return documents;
    }

    public static String getFileContext (File file) {
        String context = "";

        try {
            Scanner scanner = new Scanner(file);

            while (scanner.hasNextLine()) {
                context += " " + scanner.nextLine();
            }
        }

        catch (FileNotFoundException exception) {
            exception.printStackTrace();
        }

        return context;
    }

    public static String [] detectFileNames() {

        File file = new File(FOLDER);
        String [] fileNames = file.list();
        return  fileNames;
    }
}
