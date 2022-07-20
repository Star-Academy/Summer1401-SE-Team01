package com;

import com.Doc;
import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.Scanner;

public class FileReader {
    private static ArrayList<Doc> documents = new ArrayList<Doc>();

    public static ArrayList<Doc> readFiles() {
        String [] filesName = detectFilesName();

        for (int i = 0; i < filesName.length; i++) {
                File file = new File("tests/" + filesName[i]);
                String context = getFileContext(file);

                documents.add(new Doc(filesName[i], context));
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

    public static String [] detectFilesName() {

        File file = new File("tests/");
        String [] filesName = file.list();
        return  filesName;
    }
}
