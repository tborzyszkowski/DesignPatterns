import java.io.*;
import java.util.Arrays;
import java.util.Set;
import java.util.stream.Collectors;

/**
 *
 * przykład wykorzystania struktury wzorca dekorator wbudowanej w jave
 * Created by jakub on 1/1/17.
 */
public class CensorshipStream extends FilterInputStream {

    private BufferedReader bufferedReader;
    private int lineIdx;
    private int linseSize;
    byte[] bData;
    private final Set<String> censoredWords;
    private final String censoredText = "<CENSORED>";

    /**
     * @param input stream reprezentujący składnik dekoratora
     * @param censoredWords, słowa niedozwolone które będą zastąpione znacznikiem cenzury
     */
    public CensorshipStream(InputStream in, Set<String> censoredWords) {
        super(in);
        bufferedReader = new BufferedReader(new InputStreamReader(in));
        this.censoredWords = censoredWords;
    }

    @Override
    public int read() throws IOException {
        if (lineIdx == linseSize) {
            censor();
            if (bData == null) {
                return -1;
            }
        }

        //get the unsigned byte value, by converting it to short and then masking out the original bits from the byte, to display it as an unsigned value.
        int value = bData[lineIdx] & 0xff;
        lineIdx++;
        return value;
    }

    @Override
    public int read(byte[] b) throws IOException {
        return read(b, 0, b.length);
    }

    @Override
    public int read(byte[] b, int off, int len) throws IOException {
        if (lineIdx == linseSize) {
            censor();
        }
        if (bData == null) {
            return -1;
        }
        int lenRemaining = len;

        while (available() < lenRemaining) {
            System.arraycopy(bData,
                    lineIdx,
                    b,
                    off + (len - lenRemaining),
                    available());
            lenRemaining -= available();
            censor();
            if (bData == null) {
                return len;
            }
        }

        System.arraycopy(bData,
                lineIdx,
                b,
                off + (len - lenRemaining),
                lenRemaining);
        lineIdx += lenRemaining;
        return len;
    }

    @Override
    public long skip(long len) throws IOException {
        if (lineIdx == linseSize) {
            censor();
            if (bData == null) {
                return -1;
            }
        }

        long lenRemaining = len;

        while (available() < lenRemaining) {
            lenRemaining -= available();
            censor();

        }

        lineIdx += (int) lenRemaining;
        return len;
    }

    @Override
    public int available() throws IOException {
        return linseSize - lineIdx;
    }

    @Override
    public void close() throws IOException {
        linseSize = 0;
        lineIdx = 0;
        bufferedReader.close();
    }

    @Override
    public synchronized void mark(int readlimit) {
        //todo
        // super.mark(readlimit);
    }

    @Override
    public synchronized void reset() throws IOException {
        //super.reset();
        bufferedReader.reset();
    }

    @Override
    public boolean markSupported() {
        return false;
    }

    private void censor() {

        try {
            String line = bufferedReader.readLine();
            if (line != null) {
                String[] words = line.split("\\s+");
                for (int i = 0; i < words.length; i++) {
                    words[i] = words[i].replaceAll("[^\\w]", "");
                }
                line = Arrays.stream(words).filter(word -> censoredWords.contains(word.toLowerCase()))
                        .reduce(line, (reductionLine, word) -> reductionLine.replaceAll(word, censoredText)).toString();
                //System.out.println("DEBUG: replaced line => " + line);
                bData = line.getBytes();
                lineIdx = 0;
                linseSize = bData.length;
            } else {
                bData = null;
            }

        } catch (IOException e) {
            bData = null;
            e.printStackTrace();
        }

    }

    public static void main(String[] args) throws IOException {
        String myText = "Prorok moze dzis być swinia - jest to przykre, ale to jest fakt. \n Stanislaw Ignacy Witkiewicz";
        Set censoredWords = Arrays.stream(new String[]{"prorok", "swinia"}).collect(Collectors.toSet());
        ByteArrayInputStream rawStream = new ByteArrayInputStream(myText.getBytes());
        String result = new BufferedReader(new InputStreamReader(rawStream))
                .lines().collect(Collectors.joining("\n"));

        System.out.println("text before using censorStream: \n" + result);
        rawStream.reset();
        result = new BufferedReader(new InputStreamReader(new CensorshipStream(rawStream, censoredWords)))
                .lines().collect(Collectors.joining("\n"));
        System.out.println("text after using censorStream: \n" + result);
    }
}
