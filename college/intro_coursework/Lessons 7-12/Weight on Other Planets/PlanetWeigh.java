import java.io.*;
import java.util.*;
public class PlanetWeigh
{
    public static void main(String args[])
    {
        Scanner wei = new Scanner(System.in);
        System.out.print("What is your weight on Earth? ");
        double weight = wei.nextDouble();
        System.out.print("1. Voltar\n2. Krypton\n3. Fertos\n4. Servontos\nSelection? (Pick the number, not the planet): ");
        int select = wei.nextInt();
        switch (select)
        {
            case 1:
            System.out.println("Your weight on Voltar would be " + (weight * 0.091) + " lbs.");
            break;
            case 2:
            System.out.println("Your weight on Krypton would be " + (weight * 0.720) + " lbs.");
            break;
            case 3:
            System.out.println("Your weight on Fertos would be " + (weight * 0.865) + " lbs.");
            break;
            case 4:
            System.out.println("Your weight on Servontos would be " + (weight * 4.612) + " lbs.");
            break;
            default:
            System.out.println("Pick a number from the list; let's try it again.");
            break;
        }
    }
}